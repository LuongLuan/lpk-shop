using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LPK.ShopEcommerce.Data;

public class ShopEcommerceDbContextFactory : IDesignTimeDbContextFactory<ShopEcommerceDbContext>
{
    public ShopEcommerceDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ShopEcommerceDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ShopEcommerceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
