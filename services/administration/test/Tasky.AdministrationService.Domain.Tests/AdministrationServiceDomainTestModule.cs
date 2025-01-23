using Volo.Abp.Modularity;

namespace QLDT.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceDomainModule),
    typeof(AdministrationServiceTestBaseModule)
)]
public class AdministrationServiceDomainTestModule : AbpModule
{

}
