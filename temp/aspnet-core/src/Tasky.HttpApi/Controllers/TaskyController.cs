using QLDT.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLDT.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QLDTController : AbpControllerBase
{
    protected QLDTController()
    {
        LocalizationResource = typeof(QLDTResource);
    }
}
