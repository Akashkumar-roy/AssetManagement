using Asset_Management1.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Asset_Management1.Permissions;

public class Asset_Management1PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Asset_Management1Permissions.GroupName, L("Permission:Asset_Management1"));

        var productsPermission = myGroup.AddPermission(Asset_Management1Permissions.Products.Default, L("Permission:Products"));
        productsPermission.AddChild(Asset_Management1Permissions.Products.Create, L("Permission:Products.Create"));
        productsPermission.AddChild(Asset_Management1Permissions.Products.Edit, L("Permission:Products.Edit"));
        productsPermission.AddChild(Asset_Management1Permissions.Products.Delete, L("Permission:Products.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Asset_Management1Resource>(name);
    }
}
