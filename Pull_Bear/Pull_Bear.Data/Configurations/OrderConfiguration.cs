using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SurName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Address1).IsRequired();
            builder.Property(x => x.Address2).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.ZipCode).IsRequired();
        }
    }
}
