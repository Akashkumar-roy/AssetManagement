using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Asset_Management1.Data;
using Volo.Abp.DependencyInjection;

namespace Asset_Management1.EntityFrameworkCore;

public class EntityFrameworkCoreAsset_Management1DbSchemaMigrator
    : IAsset_Management1DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAsset_Management1DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the Asset_Management1DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Asset_Management1DbContext>()
            .Database
            .MigrateAsync();
    }
}
