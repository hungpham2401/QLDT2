﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QLDT.ProjectService.EntityFrameworkCore;

[DependsOn(
    typeof(ProjectServiceDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ProjectServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ProjectServiceDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
        context.Services.AddAbpDbContext<ProjectServiceDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}
