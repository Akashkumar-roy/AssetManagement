using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Asset_Management1.Data;

/* This is used if database provider does't define
 * IAsset_Management1DbSchemaMigrator implementation.
 */
public class NullAsset_Management1DbSchemaMigrator : IAsset_Management1DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
