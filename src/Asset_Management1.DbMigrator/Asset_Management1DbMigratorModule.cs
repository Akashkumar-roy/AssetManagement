using Asset_Management1.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Asset_Management1.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Asset_Management1EntityFrameworkCoreModule),
    typeof(Asset_Management1ApplicationContractsModule)
    )]
public class Asset_Management1DbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
