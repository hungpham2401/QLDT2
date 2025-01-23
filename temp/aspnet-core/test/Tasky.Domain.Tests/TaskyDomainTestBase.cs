using Volo.Abp.Modularity;

namespace QLDT;

/* Inherit from this class for your domain layer tests. */
public abstract class QLDTDomainTestBase<TStartupModule> : QLDTTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
