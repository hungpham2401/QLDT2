using Volo.Abp.Modularity;

namespace QLDT;

[DependsOn(
    typeof(QLDTDomainModule),
    typeof(QLDTTestBaseModule)
)]
public class QLDTDomainTestModule : AbpModule
{

}
