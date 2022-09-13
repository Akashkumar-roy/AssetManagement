using System;
using System.Collections.Generic;
using System.Text;
using Asset_Management1.Localization;
using Volo.Abp.Application.Services;

namespace Asset_Management1;

/* Inherit your application services from this class.
 */
public abstract class Asset_Management1AppService : ApplicationService
{
    protected Asset_Management1AppService()
    {
        LocalizationResource = typeof(Asset_Management1Resource);
    }
}
