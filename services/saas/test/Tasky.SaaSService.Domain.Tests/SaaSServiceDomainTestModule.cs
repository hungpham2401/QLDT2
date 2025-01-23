using Volo.Abp.Modularity;

namespace QLDT.SaaSService;

[DependsOn(
    typeof(SaaSServiceDomainModule),
    typeof(SaaSServiceTestBaseModule)
)]
public class SaaSServiceDomainTestModule : AbpModule
{

}
