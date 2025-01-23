using Volo.Abp.Modularity;

namespace QLDT.ProjectService;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class ProjectServiceDomainTestBase<TStartupModule> : ProjectServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
