using LPK.ShopEcommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LPK.ShopEcommerce.Admin;

[DependsOn(
    typeof(ShopEcommerceEntityFrameworkCoreTestModule)
    )]
public class ShopEcommerceAdminDomainTestModule : AbpModule
{

}
