using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Care).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.BodyFitId).IsRequired();
            builder.Property(x => x.Composition).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DiscountPrice).HasColumnType("money");
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
            builder.Property(x => x.ProductImage).IsRequired();
            builder.Property(x => x.ShopImage).IsRequired();
            builder.Property(x => x.MainImage1).IsRequired();
            builder.Property(x => x.MainImage2).IsRequired();
            builder.Property(x => x.PhotoModelIndicators).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Seria).IsRequired().HasMaxLength(12);

        }
    }
}
