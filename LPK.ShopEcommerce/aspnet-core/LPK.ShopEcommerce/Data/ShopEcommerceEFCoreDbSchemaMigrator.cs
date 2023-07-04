using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace LPK.ShopEcommerce.Data;

public class ShopEcommerceEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public ShopEcommerceEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ShopEcommerceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ShopEcommerceDbContext>()
            .Database
            .MigrateAsync();
    }
}
