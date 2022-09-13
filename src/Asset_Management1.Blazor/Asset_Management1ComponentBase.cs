using Asset_Management1.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Asset_Management1.Blazor;

public abstract class Asset_Management1ComponentBase : AbpComponentBase
{
    protected Asset_Management1ComponentBase()
    {
        LocalizationResource = typeof(Asset_Management1Resource);
    }
}
