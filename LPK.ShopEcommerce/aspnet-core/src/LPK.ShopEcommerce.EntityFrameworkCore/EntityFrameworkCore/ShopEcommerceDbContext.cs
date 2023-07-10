using LPK.ShopEcommerce.Attributies;
using LPK.ShopEcommerce.Configurations.Inventories;
using LPK.ShopEcommerce.Configurations.InventoryTickets;
using LPK.ShopEcommerce.Configurations.Manufacturers;
using LPK.ShopEcommerce.Configurations.Orders;
using LPK.ShopEcommerce.Configurations.ProductAttributies;
using LPK.ShopEcommerce.Configurations.ProductCategories;
using LPK.ShopEcommerce.Configurations.Products;
using LPK.ShopEcommerce.Configurations.Promotions;
using LPK.ShopEcommerce.Inventories;
using LPK.ShopEcommerce.InventoryTickets;
using LPK.ShopEcommerce.Manufacturies;
using LPK.ShopEcommerce.Orders;
using LPK.ShopEcommerce.ProductCategories;
using LPK.ShopEcommerce.Products;
using LPK.ShopEcommerce.Promotions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace LPK.ShopEcommerce.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ShopEcommerceDbContext :
    AbpDbContext<ShopEcommerceDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region Ecommerce
    public DbSet<Attribute> Attributes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryTicket> InventoryTickets { get; set; }
    public DbSet<InventoryTicketItem> InventoryTicketItems { get; set; }
    public DbSet<Manufacturer> Manufactures { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderTransaction> OrderTransactions { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttributeDateTime> ProductAttributesDateTime { get; set; }
    public DbSet<ProductAttributeDecimail> ProductAttributeDecimails { get; set; }
    public DbSet<ProductAttributeInt> ProductAttributesInts { get; set; }
    public DbSet<ProductAttributeText> ProductAttributeTexts { get; set; }
    public DbSet<ProductLink> ProductLinks { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionCategory> PromotionCategories { get; set; }
    public DbSet<PromotionManufacturer> PromotionManufacturers { get; set; }
    public DbSet<PromotionProduct> PromotionProducts { get; set; }
    public DbSet<PromotionUsageHistory> PromotionUsageHistories { get; set; }


    #endregion

    public ShopEcommerceDbContext(DbContextOptions<ShopEcommerceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.ApplyConfiguration(new ProductAttributeConfiguration());

        builder.ApplyConfiguration(new InventoryConfiguration());

        builder.ApplyConfiguration(new InventoryTicketConfiguration());
        builder.ApplyConfiguration(new InventoryTicketItemConfiguration());

        builder.ApplyConfiguration(new ManufacturerConfiguration());

        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new OrderTransactionConfiguration());

        builder.ApplyConfiguration(new ProductCategoryConfiguration());

        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new ProductLinkConfiguration());
        builder.ApplyConfiguration(new ProductReviewConfiguration());
        builder.ApplyConfiguration(new ProductTagConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new ProductAttributeDateTimeConfiguration());
        builder.ApplyConfiguration(new ProductAttributeDecimalConfiguration());
        builder.ApplyConfiguration(new ProductAttributeIntConfiguration());
        builder.ApplyConfiguration(new ProductAttributeTextConfiguration());
        builder.ApplyConfiguration(new ProductAttributeVarcharConfiguration());

        builder.ApplyConfiguration(new PromotionConfiguration());
        builder.ApplyConfiguration(new PromotionCategoryConfiguration());
        builder.ApplyConfiguration(new PromotionManufacturerConfiguration());
        builder.ApplyConfiguration(new PromotionProductConfiguration());
        builder.ApplyConfiguration(new PromotionUsageHistoryConfiguration());
    }
}
