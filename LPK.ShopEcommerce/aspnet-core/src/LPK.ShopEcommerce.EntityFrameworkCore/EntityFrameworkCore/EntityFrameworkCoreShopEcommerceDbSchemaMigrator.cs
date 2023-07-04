using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LPK.ShopEcommerce.Data;
using Volo.Abp.DependencyInjection;

namespace LPK.ShopEcommerce.EntityFrameworkCore;

public class EntityFrameworkCoreShopEcommerceDbSchemaMigrator
    : IShopEcommerceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreShopEcommerceDbSchemaMigrator(
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
