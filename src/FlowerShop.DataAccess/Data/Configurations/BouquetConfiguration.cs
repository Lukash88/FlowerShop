using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations;

public sealed class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
{
    public void Configure(EntityTypeBuilder<Bouquet> builder)
    {
        builder
            .Property(b => b.Occasion)
            .HasConversion(
                o => o.ToString(),
                o => Enum.Parse<Occasion>(o))
            .IsRequired();

        builder
            .Property(b => b.TypeOfArrangement)
            .HasConversion(
                t => t.ToString(),
                t => Enum.Parse<TypeOfFlowerArrangement>(t))
            .IsRequired();

        builder
            .Property(b => b.DecorationWay)
            .HasConversion(
                dw => dw.ToString(),
                dw => Enum.Parse<DecorationWay>(dw))
            .IsRequired();
    }
}
