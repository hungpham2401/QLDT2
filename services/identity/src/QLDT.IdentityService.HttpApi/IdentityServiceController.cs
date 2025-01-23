using QLDT.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLDT.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}
