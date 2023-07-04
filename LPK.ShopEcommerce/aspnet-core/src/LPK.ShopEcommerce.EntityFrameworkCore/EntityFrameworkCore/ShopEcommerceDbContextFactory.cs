using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LPK.ShopEcommerce.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ShopEcommerceDbContextFactory : IDesignTimeDbContextFactory<ShopEcommerceDbContext>
{
    public ShopEcommerceDbContext CreateDbContext(string[] args)
    {
        ShopEcommerceEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ShopEcommerceDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ShopEcommerceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LPK.ShopEcommerce.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
