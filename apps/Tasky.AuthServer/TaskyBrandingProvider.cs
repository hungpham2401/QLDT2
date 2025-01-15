using Microsoft.Extensions.Localization;
using Tasky.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Tasky;

[Dependency(ReplaceServices = true)]
public class TaskyBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TaskyResource> _localizer;

    public TaskyBrandingProvider(IStringLocalizer<TaskyResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
