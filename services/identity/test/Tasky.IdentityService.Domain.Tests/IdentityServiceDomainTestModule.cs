using Volo.Abp.Modularity;

namespace Tasky.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainModule),
    typeof(IdentityServiceTestBaseModule)
)]
public class IdentityServiceDomainTestModule : AbpModule
{

}
