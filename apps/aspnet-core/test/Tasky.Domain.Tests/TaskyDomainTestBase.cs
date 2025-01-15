using Volo.Abp.Modularity;

namespace Tasky;

/* Inherit from this class for your domain layer tests. */
public abstract class TaskyDomainTestBase<TStartupModule> : TaskyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
