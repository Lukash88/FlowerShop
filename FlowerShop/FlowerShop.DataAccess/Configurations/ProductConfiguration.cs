namespace FlowerShop.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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