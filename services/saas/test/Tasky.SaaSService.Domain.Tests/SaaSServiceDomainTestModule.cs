using Volo.Abp.Modularity;

namespace Tasky.SaaSService;

[DependsOn(
    typeof(SaaSServiceDomainModule),
    typeof(SaaSServiceTestBaseModule)
)]
public class SaaSServiceDomainTestModule : AbpModule
{

}
