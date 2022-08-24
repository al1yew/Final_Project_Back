using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pull_Bear.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Configurations
{
    public class BodyFitConfiguration : IEntityTypeConfiguration<BodyFit>
    {
        public void Configure(EntityTypeBuilder<BodyFit> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(255);
        }
    }
}
