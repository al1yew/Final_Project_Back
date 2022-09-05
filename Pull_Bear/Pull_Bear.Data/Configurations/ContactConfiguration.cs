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
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Subject).IsRequired();
        }
    }
}
