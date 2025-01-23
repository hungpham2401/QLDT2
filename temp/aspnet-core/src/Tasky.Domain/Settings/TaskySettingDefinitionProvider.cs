using Volo.Abp.Settings;

namespace QLDT.Settings;

public class QLDTSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(QLDTSettings.MySetting1));
    }
}
