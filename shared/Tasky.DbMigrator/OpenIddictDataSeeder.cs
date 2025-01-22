using Microsoft.Extensions.Configuration;
using Tasky.DbMigrator.Model;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using Microsoft.Extensions.Localization;
using OpenIddict.Abstractions;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp;
using System.Diagnostics.CodeAnalysis;

namespace Tasky.DbMigrator
{
    public class OpenIddictDataSeeder : ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IAbpApplicationManager _applicationManager;
        private readonly IOpenIddictScopeManager _scopeManager;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly IStringLocalizer<OpenIddictResponse> L;

        public OpenIddictDataSeeder(
            IAbpApplicationManager applicationManager,
            IOpenIddictScopeManager scopeManager,
            IPermissionDataSeeder permissionDataSeeder,
            IStringLocalizer<OpenIddictResponse> l,
            IGuidGenerator guidGenerator,
            IConfiguration configuration,
            ICurrentTenant currentTenant)
        {
            _configuration = configuration;
            _applicationManager = applicationManager;
            _scopeManager = scopeManager;
            _permissionDataSeeder = permissionDataSeeder;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            L = l;
        }

        [UnitOfWork]
        public async virtual Task SeedAsync()
        {
            using (_currentTenant.Change(null))
            {
                await CreateApiResourcesAsync();
                await CreateClientsAsync();
            }
        }

        private async Task CreateClientsAsync()
        {
            var clients = _configuration.GetSection("Clients").Get<List<ServiceClient>>();

            // Các scope "built-in" (luôn có).
            var commonScopes = new[] {
                OpenIddictConstants.Permissions.Scopes.Address,
                OpenIddictConstants.Permissions.Scopes.Email,
                OpenIddictConstants.Permissions.Scopes.Phone,
                OpenIddictConstants.Permissions.Scopes.Profile,
                OpenIddictConstants.Permissions.Scopes.Roles,
                "offline_access"
            };

            foreach (var client in clients)
            {
                // Nếu ClientSecret rỗng -> Public, nếu có -> Confidential
                var isClientSecretAvailable = !string.IsNullOrEmpty(client.ClientSecret);

                await CreateClientAsync(
                    name: client.ClientId,
                    type: isClientSecretAvailable
                        ? OpenIddictConstants.ClientTypes.Confidential
                        : OpenIddictConstants.ClientTypes.Public,
                    consentType: OpenIddictConstants.ConsentTypes.Implicit,
                    displayName: client.ClientId,
                    secret: isClientSecretAvailable ? client.ClientSecret : null,
                    scopes: commonScopes.Union(client.Scopes).ToList(),
                    grantTypes: client.GrantTypes.ToList(),
                    redirectUris: client.RedirectUris,
                    postLogoutRedirectUris: client.PostLogoutRedirectUris
                );
            }
        }

        private async Task CreateApiResourcesAsync()
        {
            var apiResources = _configuration.GetSection("ApiResource").Get<string[]>();

            foreach (var item in apiResources)
            {
                await CreateApiResourceAsync(item);
            }
        }

        private async Task CreateApiResourceAsync(string name)
        {
            if (await _scopeManager.FindByNameAsync(name) == null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
                {
                    Name = name,
                    DisplayName = $"{name} API",
                    Resources = { name }
                });
            }
        }

        private async Task CreateClientAsync(
            [NotNull] string name,
            [NotNull] string type,
            [NotNull] string consentType,
            string displayName,
            string secret,
            List<string> grantTypes,
            List<string> scopes,
            string[] redirectUris = null,
            string[] postLogoutRedirectUris = null,
            List<string> permissions = null)
        {
            // Nếu type=public nhưng lại có secret => báo lỗi
            if (!string.IsNullOrEmpty(secret) &&
                string.Equals(type, OpenIddictConstants.ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessException(L["NoClientSecretCanBeSetForPublicApplications"]);
            }

            // Nếu type=confidential nhưng không có secret => báo lỗi
            if (string.IsNullOrEmpty(secret) &&
                string.Equals(type, OpenIddictConstants.ClientTypes.Confidential, StringComparison.OrdinalIgnoreCase))
            {
                throw new BusinessException(L["TheClientSecretIsRequiredForConfidentialApplications"]);
            }

            // Tìm client cũ cùng ClientId và xóa, để tạo mới
            if (!string.IsNullOrEmpty(name))
            {
                var existingClient = await _applicationManager.FindByClientIdAsync(name);
                if (existingClient != null)
                {
                    await _applicationManager.DeleteAsync(existingClient);
                }
            }

            // Tạo client mới
            var client = await _applicationManager.FindByClientIdAsync(name);
            if (client == null)
            {
                var application = new OpenIddictApplicationDescriptor
                {
                    ClientId = name,
                    // Quan trọng: Gán ApplicationType = type (public/confidential) theo param
                    ApplicationType = type,
                    ClientSecret = secret,
                    ConsentType = consentType,
                    DisplayName = displayName
                };

                // (Tuỳ chọn) Ép dùng PKCE cho Authorization Code flow => SPA an toàn hơn:
                // application.Requirements.Add(OpenIddictConstants.Requirements.Features.ProofKeyForCodeExchange);

                Check.NotNullOrEmpty(grantTypes, nameof(grantTypes));
                Check.NotNullOrEmpty(scopes, nameof(scopes));

                // Nếu grantTypes chứa "authorization_code" + "implicit" => cho phép CodeIdToken...
                if (new[] {
                        OpenIddictConstants.GrantTypes.AuthorizationCode,
                        OpenIddictConstants.GrantTypes.Implicit
                    }.All(grantTypes.Contains))
                {
                    application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.CodeIdToken);

                    // Nếu client là public, cho phép thêm CodeIdTokenToken, CodeToken
                    if (string.Equals(type, OpenIddictConstants.ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
                    {
                        application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.CodeIdTokenToken);
                        application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.CodeToken);
                    }
                }

                // Luôn cho phép logout endpoint
                application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Logout);

                foreach (var grantType in grantTypes)
                {
                    switch (grantType)
                    {
                        case OpenIddictConstants.GrantTypes.AuthorizationCode:
                            application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode);
                            application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.Code);
                            // Cho phép /connect/authorize
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Authorization);
                            // Cho phép /connect/token,...
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Token);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Revocation);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Introspection);
                            break;

                        case OpenIddictConstants.GrantTypes.Implicit:
                            application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.Implicit);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Authorization);
                            // Nếu là public => cho phép IdTokenToken, Token
                            application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.IdToken);
                            if (string.Equals(type, OpenIddictConstants.ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
                            {
                                application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.IdTokenToken);
                                application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.Token);
                            }
                            break;

                        case OpenIddictConstants.GrantTypes.ClientCredentials:
                            application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.ClientCredentials);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Token);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Revocation);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Introspection);
                            break;

                        case OpenIddictConstants.GrantTypes.Password:
                            application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.Password);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Token);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Revocation);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Introspection);
                            break;

                        case OpenIddictConstants.GrantTypes.RefreshToken:
                            application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.RefreshToken);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Token);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Revocation);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Introspection);
                            break;

                        case OpenIddictConstants.GrantTypes.DeviceCode:
                            application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.DeviceCode);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Device);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Token);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Revocation);
                            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Introspection);
                            break;
                    }
                }

                // Các scope built-in
                var builtInScopes = new[]
                {
                    OpenIddictConstants.Permissions.Scopes.Address,
                    OpenIddictConstants.Permissions.Scopes.Email,
                    OpenIddictConstants.Permissions.Scopes.Phone,
                    OpenIddictConstants.Permissions.Scopes.Profile,
                    OpenIddictConstants.Permissions.Scopes.Roles,
                    "offline_access"
                };

                // Thêm scope vào Permissions
                foreach (var scope in scopes)
                {
                    if (builtInScopes.Contains(scope))
                    {
                        application.Permissions.Add(scope);
                    }
                    else
                    {
                        application.Permissions.Add(OpenIddictConstants.Permissions.Prefixes.Scope + scope);
                    }
                }

                // Xử lý Redirect Uris
                if (redirectUris != null)
                {
                    foreach (var redirectUri in redirectUris)
                    {
                        if (!redirectUri.IsNullOrEmpty())
                        {
                            if (!Uri.TryCreate(redirectUri, UriKind.Absolute, out var uri) ||
                                !uri.IsWellFormedOriginalString())
                            {
                                throw new BusinessException(L["InvalidRedirectUri", redirectUri]);
                            }

                            if (application.RedirectUris.All(x => x != uri))
                            {
                                application.RedirectUris.Add(uri);
                            }
                        }
                    }
                }

                // Xử lý PostLogoutRedirectUris
                if (postLogoutRedirectUris != null)
                {
                    foreach (var postLogoutRedirectUri in postLogoutRedirectUris)
                    {
                        if (!postLogoutRedirectUri.IsNullOrEmpty())
                        {
                            if (!Uri.TryCreate(postLogoutRedirectUri, UriKind.Absolute, out var uri) ||
                                !uri.IsWellFormedOriginalString())
                            {
                                throw new BusinessException(L["InvalidPostLogoutRedirectUri", postLogoutRedirectUri]);
                            }

                            if (application.PostLogoutRedirectUris.All(x => x != uri))
                            {
                                application.PostLogoutRedirectUris.Add(uri);
                            }
                        }
                    }
                }

                // Nếu có danh sách quyền -> seed
                if (permissions != null)
                {
                    await _permissionDataSeeder.SeedAsync(
                        ClientPermissionValueProvider.ProviderName,
                        name,
                        permissions,
                        null
                    );
                }

                await _applicationManager.CreateAsync(application);
            }
        }
    }
}
