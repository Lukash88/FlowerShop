using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.FlowerType)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.LengthInCm)
                .IsRequired();

            builder.Property(x => x.Colour)
                .IsRequired();

            builder.Property(x => x.StockLevel)
                .IsRequired();

            builder
               .Property(x => x.Price)
               .HasPrecision(14, 2)
               .IsRequired(false);
        }
    }
}