using System;
using System.Collections.Generic;
using System.Text;
using QLDT.Localization;
using Volo.Abp.Application.Services;

namespace QLDT;

/* Inherit your application services from this class.
 */
public abstract class QLDTAppService : ApplicationService
{
    protected QLDTAppService()
    {
        LocalizationResource = typeof(QLDTResource);
    }
}
