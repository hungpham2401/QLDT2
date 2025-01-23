using Volo.Abp.Modularity;

namespace QLDT.ProjectService;

[DependsOn(
    typeof(ProjectServiceApplicationModule),
    typeof(ProjectServiceDomainTestModule)
    )]
public class ProjectServiceApplicationTestModule : AbpModule
{

}
