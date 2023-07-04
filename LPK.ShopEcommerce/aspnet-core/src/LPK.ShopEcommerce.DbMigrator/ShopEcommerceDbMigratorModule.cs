using LPK.ShopEcommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LPK.ShopEcommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ShopEcommerceEntityFrameworkCoreModule),
    typeof(ShopEcommerceApplicationContractsModule)
    )]
public class ShopEcommerceDbMigratorModule : AbpModule
{

}
