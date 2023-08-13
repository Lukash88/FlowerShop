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

            builder
                .HasMany(x => x.Flowers)
                .WithMany(x => x.Bouquets)
                .UsingEntity<BouquetFlower>(
                x => x.HasOne(x => x.Flower).WithMany().HasForeignKey(x => x.FlowerId).OnDelete(DeleteBehavior.NoAction),
                x => x.HasOne(x => x.Bouquet).WithMany().HasForeignKey(x => x.BouquetId).OnDelete(DeleteBehavior.NoAction));
        }
    }
}