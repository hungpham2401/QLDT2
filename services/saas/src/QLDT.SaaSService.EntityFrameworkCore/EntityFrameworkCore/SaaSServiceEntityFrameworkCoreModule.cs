using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace QLDT.SaaSService.EntityFrameworkCore;

[DependsOn(
    typeof(SaaSServiceDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule)
)]
public class SaaSServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        context.Services.AddAbpDbContext<SaaSServiceDbContext>(options =>
        {
            options.ReplaceDbContext<ITenantManagementDbContext>();
            options.AddDefaultRepositories(true);
        });
    }
}
