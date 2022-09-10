using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.CardHolder).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CardNo).IsRequired().HasMaxLength(16);
            builder.Property(x => x.CVV).IsRequired().HasMaxLength(4);
            builder.Property(x => x.ExpireDate).IsRequired().HasMaxLength(7);
        }
    }
}
