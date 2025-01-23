using Microsoft.Extensions.Localization;
using QLDT.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace QLDT;

[Dependency(ReplaceServices = true)]
public class QLDTBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<QLDTResource> _localizer;

    public QLDTBrandingProvider(IStringLocalizer<QLDTResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
