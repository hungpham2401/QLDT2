using Volo.Abp.Modularity;

namespace QLDT.ProjectService;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class ProjectServiceApplicationTestBase<TStartupModule> : ProjectServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
