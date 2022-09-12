using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Address1).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Address2).HasMaxLength(40);
            builder.Property(x => x.City).IsRequired().HasMaxLength(22);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(60);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(12);
        }
    }
}
