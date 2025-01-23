using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QLDT.ProjectService.EntityFrameworkCore;

[ConnectionStringName(ProjectServiceDbProperties.ConnectionStringName)]
public class ProjectServiceDbContext : AbpDbContext<ProjectServiceDbContext>, IProjectServiceDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ProjectServiceDbContext(DbContextOptions<ProjectServiceDbContext> options)
        : base(options)
    {

    }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProjectService();

    }
}
