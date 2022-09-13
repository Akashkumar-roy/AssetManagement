using System.Threading.Tasks;

namespace Asset_Management1.Data;

public interface IAsset_Management1DbSchemaMigrator
{
    Task MigrateAsync();
}
