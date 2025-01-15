using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tasky.ProjectService.EntityFrameworkCore;

public class ProjectServiceHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProjectServiceHttpApiHostMigrationsDbContext>
{
    public ProjectServiceHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ProjectServiceHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ProjectService"));

        return new ProjectServiceHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
