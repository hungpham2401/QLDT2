using QLDT.SaaSService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLDT.SaaSService;

public abstract class SaaSServiceController : AbpControllerBase
{
    protected SaaSServiceController()
    {
        LocalizationResource = typeof(SaaSServiceResource);
    }
}
