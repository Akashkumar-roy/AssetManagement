using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Asset_Management1.Blazor;

[Dependency(ReplaceServices = true)]
public class Asset_Management1BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Asset_Management1";
}
