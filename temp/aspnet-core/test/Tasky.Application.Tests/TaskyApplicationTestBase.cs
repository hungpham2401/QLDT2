using Volo.Abp.Modularity;

namespace QLDT;

public abstract class QLDTApplicationTestBase<TStartupModule> : QLDTTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
