using QLDT.ProjectService.Localization;
using Volo.Abp.Application.Services;

namespace QLDT.ProjectService;

public abstract class ProjectServiceAppService : ApplicationService
{
    protected ProjectServiceAppService()
    {
        LocalizationResource = typeof(ProjectServiceResource);
        ObjectMapperContext = typeof(ProjectServiceApplicationModule);
    }
}
