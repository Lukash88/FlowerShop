using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

            builder
                .Property(p => p.ShortDescription)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(p => p.LongDescription)
                .HasMaxLength(500);

            builder
               .Property(p => p.Category)
               .HasConversion(
                   c => c.ToString(),
                   c => (Category)Enum.Parse(typeof(Category), c))
               .IsRequired();

            builder
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            builder
                .Property(p => p.StockLevel)
                .IsRequired();
        }
    }
}