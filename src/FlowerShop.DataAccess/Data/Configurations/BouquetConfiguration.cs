using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
    {
        public void Configure(EntityTypeBuilder<Bouquet> builder)
        {
            builder
                .Property(b => b.Occasion)
                .HasConversion(
            o => o.ToString(),
            o => (Occasion)Enum.Parse(typeof(Occasion), o))
                .IsRequired();

            builder
                .Property(b => b.TypeOfArrangement)
                .HasConversion(
                    t => t.ToString(),
                    t => (TypeOfFlowerArrangement)Enum.Parse(typeof(TypeOfFlowerArrangement), t))
                .IsRequired();

            builder
                .Property(b => b.DecorationWay)
                .HasConversion(
                    dw => dw.ToString(),
                    dw => (DecorationWay)Enum.Parse(typeof(DecorationWay), dw))
                .IsRequired();
        }
    }
}