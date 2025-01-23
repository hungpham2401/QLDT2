using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace QLDT.AdministrationService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AdministrationServiceConsoleApiClientModule : AbpModule
{

}
