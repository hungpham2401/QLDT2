using Volo.Abp.Modularity;

namespace Tasky.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceDomainModule),
    typeof(AdministrationServiceTestBaseModule)
)]
public class AdministrationServiceDomainTestModule : AbpModule
{

}
