using System.Threading.Tasks;

namespace QLDT.Data;

public interface IQLDTDbSchemaMigrator
{
    Task MigrateAsync();
}
