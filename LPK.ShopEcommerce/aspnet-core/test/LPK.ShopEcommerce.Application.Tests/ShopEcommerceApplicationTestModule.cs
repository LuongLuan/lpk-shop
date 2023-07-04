using Volo.Abp.Modularity;

namespace LPK.ShopEcommerce;

[DependsOn(
    typeof(ShopEcommerceApplicationModule),
    typeof(ShopEcommerceDomainTestModule)
    )]
public class ShopEcommerceApplicationTestModule : AbpModule
{

}
