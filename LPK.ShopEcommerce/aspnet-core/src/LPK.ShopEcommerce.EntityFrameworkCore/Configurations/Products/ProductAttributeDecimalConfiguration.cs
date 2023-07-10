using LPK.ShopEcommerce.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPK.ShopEcommerce.Configurations.Products
{
    public class ProductAttributeDecimalConfiguration : IEntityTypeConfiguration<ProductAttributeDecimail>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeDecimail> builder)
        {
            builder.ToTable(ShopEcommerceConsts.DbTablePrefix + "ProductAttributeDecimals");
            builder.HasKey(x => x.Id);
        }
    }
}
