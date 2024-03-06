using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class DecorationConfiguration : IEntityTypeConfiguration<Decoration>
    {
        public void Configure(EntityTypeBuilder<Decoration> builder)
        {;

            builder
                .Property(d => d.Role)
                .HasConversion(
                    dr => dr.ToString(),
                    dr => (DecorationRole)Enum.Parse(typeof(DecorationRole), dr))
                .IsRequired();
        }
    }
}