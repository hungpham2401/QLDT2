﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace QLDT.ProjectService;

[DependsOn(
    typeof(ProjectServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ProjectServiceApplicationContractsModule : AbpModule
{

}
