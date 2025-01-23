using Volo.Abp.Modularity;

namespace QLDT.SaaSService;

[DependsOn(
    typeof(SaaSServiceApplicationModule),
    typeof(SaaSServiceDomainTestModule)
    )]
public class SaaSServiceApplicationTestModule : AbpModule
{

}
