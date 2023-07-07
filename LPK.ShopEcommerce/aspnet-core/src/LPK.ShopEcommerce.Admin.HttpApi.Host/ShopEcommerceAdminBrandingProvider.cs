using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LPK.ShopEcommerce.Admin;

[Dependency(ReplaceServices = true)]
public class ShopEcommerceAdminBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ShopEcommerce";
}
