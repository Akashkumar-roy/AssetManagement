using Volo.Abp.Modularity;

namespace Asset_Management1;

[DependsOn(
    typeof(Asset_Management1ApplicationModule),
    typeof(Asset_Management1DomainTestModule)
    )]
public class Asset_Management1ApplicationTestModule : AbpModule
{

}
