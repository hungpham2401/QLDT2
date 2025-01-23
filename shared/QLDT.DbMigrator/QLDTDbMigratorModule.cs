using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDT.AdministrationService.EntityFrameworkCore;
using QLDT.AdministrationService;
using QLDT.IdentityService.EntityFrameworkCore;
using QLDT.IdentityService;
using QLDT.SaaSService.EntityFrameworkCore;
using QLDT.SaaSService;
using Volo.Abp.Modularity;
using Volo.Abp.Autofac;
using QLDT.ProjectService.EntityFrameworkCore;
using QLDT.ProjectService;

namespace QLDT.DbMigrator;
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaaSServiceEntityFrameworkCoreModule),
    typeof(SaaSServiceApplicationContractsModule),
    typeof(ProjectServiceEntityFrameworkCoreModule),
    typeof(ProjectServiceApplicationContractsModule)
)]
public class QLDTDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }

}
