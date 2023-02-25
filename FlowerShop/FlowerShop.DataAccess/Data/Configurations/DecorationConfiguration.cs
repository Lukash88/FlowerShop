using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class DecorationConfiguration : IEntityTypeConfiguration<Decoration>
    {
        public void Configure(EntityTypeBuilder<Decoration> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Role)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(x => x.IsAvailable)
                .IsRequired();

            builder
                .Property(x => x.StockLevel)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .HasPrecision(14, 2)
                .IsRequired(false);
        }
    }
}