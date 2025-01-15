using Volo.Abp.Modularity;

namespace Tasky;

public abstract class TaskyApplicationTestBase<TStartupModule> : TaskyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
