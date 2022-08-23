using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.Property(x => x.Review).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ProductId).IsRequired();
            //builder.Property(x => x.Rating).IsRequired();
            //builder.Property(x => x.PublishDate).IsRequired();
            //builder.Property(x => x.Author).IsRequired();
        }
    }
}
