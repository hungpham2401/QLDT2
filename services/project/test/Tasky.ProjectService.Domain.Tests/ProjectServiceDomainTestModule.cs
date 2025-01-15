using Volo.Abp.Modularity;

namespace Tasky.ProjectService;

[DependsOn(
    typeof(ProjectServiceDomainModule),
    typeof(ProjectServiceTestBaseModule)
)]
public class ProjectServiceDomainTestModule : AbpModule
{

}
