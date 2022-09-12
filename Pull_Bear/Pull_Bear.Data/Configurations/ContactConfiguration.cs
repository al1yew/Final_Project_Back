using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(40);
        }
    }
}
