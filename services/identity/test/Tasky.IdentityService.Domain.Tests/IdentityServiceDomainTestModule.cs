using Volo.Abp.Modularity;

namespace QLDT.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainModule),
    typeof(IdentityServiceTestBaseModule)
)]
public class IdentityServiceDomainTestModule : AbpModule
{

}
