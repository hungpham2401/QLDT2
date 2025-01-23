using Volo.Abp.Modularity;

namespace QLDT.ProjectService;

[DependsOn(
    typeof(ProjectServiceDomainModule),
    typeof(ProjectServiceTestBaseModule)
)]
public class ProjectServiceDomainTestModule : AbpModule
{

}
