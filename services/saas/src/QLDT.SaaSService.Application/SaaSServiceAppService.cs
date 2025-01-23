using QLDT.SaaSService.Localization;
using Volo.Abp.Application.Services;

namespace QLDT.SaaSService;

public abstract class SaaSServiceAppService : ApplicationService
{
    protected SaaSServiceAppService()
    {
        LocalizationResource = typeof(SaaSServiceResource);
        ObjectMapperContext = typeof(SaaSServiceApplicationModule);
    }
}
