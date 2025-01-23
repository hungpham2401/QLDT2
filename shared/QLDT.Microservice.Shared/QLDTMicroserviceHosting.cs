using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDT.AdministrationService.EntityFrameworkCore;
using QLDT.SaaSService.EntityFrameworkCore;
using QLDT.Shared.Hosting;
using Volo.Abp.Modularity;

namespace QLDT.Microservice.Shared;
[DependsOn(
    typeof(QLDTHostingModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(SaaSServiceEntityFrameworkCoreModule)
)]
public class QLDTMicroserviceHosting : AbpModule
{
}
