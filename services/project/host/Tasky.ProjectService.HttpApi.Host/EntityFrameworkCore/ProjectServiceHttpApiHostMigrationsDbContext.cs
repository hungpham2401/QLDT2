using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Tasky.ProjectService.EntityFrameworkCore;

public class ProjectServiceHttpApiHostMigrationsDbContext : AbpDbContext<ProjectServiceHttpApiHostMigrationsDbContext>
{
    public ProjectServiceHttpApiHostMigrationsDbContext(DbContextOptions<ProjectServiceHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureProjectService();
    }
}
