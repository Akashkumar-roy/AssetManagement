using Asset_Management1.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Asset_Management1;

[DependsOn(
    typeof(Asset_Management1EntityFrameworkCoreTestModule)
    )]
public class Asset_Management1DomainTestModule : AbpModule
{

}
