using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.Property(f => f.FlowerType)
                .HasConversion(
                    ft => ft.ToString(),
                    ft => (FlowerType)Enum.Parse(typeof(FlowerType), ft))
                .IsRequired();

            builder.Property(f => f.LengthInCm)
                .IsRequired(false);

            builder.Property(f => f.Color)
                .HasConversion(
                    c => c.ToString(),
                    c => (FlowerColor)Enum.Parse(typeof(FlowerColor), c))
                .IsRequired();;
        }
    }
}