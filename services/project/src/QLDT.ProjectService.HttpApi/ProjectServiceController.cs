using QLDT.ProjectService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLDT.ProjectService;

public abstract class ProjectServiceController : AbpControllerBase
{
    protected ProjectServiceController()
    {
        LocalizationResource = typeof(ProjectServiceResource);
    }
}
