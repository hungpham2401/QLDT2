using QLDT.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QLDT.Permissions;

public class QLDTPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QLDTPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(QLDTPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QLDTResource>(name);
    }
}
