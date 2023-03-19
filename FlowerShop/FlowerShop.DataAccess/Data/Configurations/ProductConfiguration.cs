﻿using System;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(30);

            builder
                .Property(x => x.ShortDescription)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.LongDescription)
                .HasMaxLength(500);

            builder
               .Property(x => x.Category)
               .HasConversion(
                   c => c.ToString(),
                   c => (Category)Enum.Parse(typeof(Category), c))
               .IsRequired();

            builder
               .Property(x => x.Price)
               .HasPrecision(14, 2)
               .IsRequired(false);

            builder
                .Property(x => x.StockLevel)
                .IsRequired();
        }
    }
}