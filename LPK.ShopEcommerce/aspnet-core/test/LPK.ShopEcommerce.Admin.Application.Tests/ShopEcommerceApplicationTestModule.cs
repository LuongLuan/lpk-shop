using Volo.Abp.Modularity;

namespace LPK.ShopEcommerce.Admin;

[DependsOn(
    typeof(ShopEcommerceAdminApplicationModule),
    typeof(ShopEcommerceAdminDomainTestModule)
    )]
public class ShopEcommerceApplicationTestModule : AbpModule
{

}
