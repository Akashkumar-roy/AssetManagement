using Asset_Management1.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Asset_Management1.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Asset_Management1Controller : AbpControllerBase
{
    protected Asset_Management1Controller()
    {
        LocalizationResource = typeof(Asset_Management1Resource);
    }
}
