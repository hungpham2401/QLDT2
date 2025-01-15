using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasky.AdministrationService.EntityFrameworkCore;
using Tasky.SaaSService.EntityFrameworkCore;
using Tasky.Shared.Hosting;
using Volo.Abp.Modularity;

namespace Tasky.Microservice.Shared;
[DependsOn(
    typeof(TaskyHostingModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(SaaSServiceEntityFrameworkCoreModule)
)]
public class TaskyMicroserviceHosting : AbpModule
{
}
