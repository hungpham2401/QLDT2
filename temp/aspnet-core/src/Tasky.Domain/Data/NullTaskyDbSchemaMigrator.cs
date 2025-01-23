using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace QLDT.Data;

/* This is used if database provider does't define
 * IQLDTDbSchemaMigrator implementation.
 */
public class NullQLDTDbSchemaMigrator : IQLDTDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
