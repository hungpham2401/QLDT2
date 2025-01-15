using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.AdministrationService.EntityFrameworkCore;
using Tasky.AdministrationService;
using Tasky.IdentityService.EntityFrameworkCore;
using Tasky.IdentityService;
using Tasky.SaaSService.EntityFrameworkCore;
using Tasky.SaaSService;
using Volo.Abp.Modularity;
using Volo.Abp.Autofac;
using Tasky.ProjectService.EntityFrameworkCore;
using Tasky.ProjectService;

namespace Tasky.DbMigrator;
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
public class TaskyDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }

}
