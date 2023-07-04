using System.Threading.Tasks;

namespace LPK.ShopEcommerce.Data;

public interface IShopEcommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
