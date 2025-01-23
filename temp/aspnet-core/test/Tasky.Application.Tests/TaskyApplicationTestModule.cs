using Volo.Abp.Modularity;

namespace QLDT;

[DependsOn(
    typeof(QLDTApplicationModule),
    typeof(QLDTDomainTestModule)
)]
public class QLDTApplicationTestModule : AbpModule
{

}
