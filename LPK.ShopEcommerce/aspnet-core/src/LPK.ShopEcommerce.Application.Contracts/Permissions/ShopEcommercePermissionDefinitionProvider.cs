using LPK.ShopEcommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LPK.ShopEcommerce.Permissions;

public class ShopEcommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ShopEcommercePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ShopEcommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ShopEcommerceResource>(name);
    }
}
