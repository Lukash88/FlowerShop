using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.Configurations
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
               .IsRequired()
               .HasMaxLength(30);
        }
    }
}