using LPK.ShopEcommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LPK.ShopEcommerce;

[DependsOn(
    typeof(ShopEcommerceEntityFrameworkCoreTestModule)
    )]
public class ShopEcommerceDomainTestModule : AbpModule
{

}
