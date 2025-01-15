using Volo.Abp.Modularity;

namespace Tasky;

[DependsOn(
    typeof(TaskyDomainModule),
    typeof(TaskyTestBaseModule)
)]
public class TaskyDomainTestModule : AbpModule
{

}
