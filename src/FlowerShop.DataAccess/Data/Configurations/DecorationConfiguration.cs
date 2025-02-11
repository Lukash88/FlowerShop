﻿using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations;

public sealed class DecorationConfiguration : IEntityTypeConfiguration<Decoration>
{
    public void Configure(EntityTypeBuilder<Decoration> builder)
    {
        builder
            .Property(d => d.Role)
            .HasConversion(
                dr => dr.ToString(),
                dr => Enum.Parse<DecorationRole>(dr))
            .IsRequired();
    }
}