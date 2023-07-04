using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LPK.ShopEcommerce;

[Dependency(ReplaceServices = true)]
public class ShopEcommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ShopEcommerce";
}
