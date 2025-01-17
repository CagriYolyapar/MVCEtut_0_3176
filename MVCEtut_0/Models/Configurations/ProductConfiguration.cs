﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEtut_0.Models.Entities;

namespace MVCEtut_0.Models.Configurations
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UnitPrice).HasColumnType("money");
        }
    }
}
