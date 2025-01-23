using QLDT.AdministrationService.Localization;
using Volo.Abp.Application.Services;

namespace QLDT.AdministrationService;

public abstract class AdministrationServiceAppService : ApplicationService
{
    protected AdministrationServiceAppService()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
        ObjectMapperContext = typeof(AdministrationServiceApplicationModule);
    }
}
