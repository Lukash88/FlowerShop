namespace FlowerShop.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder
              .Property(x => x.Description)
              .IsRequired()
              .HasMaxLength(200);

            builder
              .Property(x => x.Category)
              .IsRequired()
              .HasMaxLength(100);

            builder
               .Property(x => x.Price)
               .HasPrecision(14, 2)
               .IsRequired(false);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            builder
                .HasMany(x => x.Bouquets)
                .WithMany(x => x.OrderDetails)
                .UsingEntity<BouquetOrderDetail>(
                    x => x.HasOne(x => x.Bouquet).WithMany().HasForeignKey(x => x.BouquetId),
                    x => x.HasOne(x => x.OrderDetail).WithMany().HasForeignKey(x => x.OrderDetailId));

            builder
                .HasMany(x => x.Decorations)
                .WithMany(x => x.OrderDetails)
                .UsingEntity<DecorationOrderDetail>(
                    x => x.HasOne(x => x.Decoration).WithMany().HasForeignKey(x => x.DecorationId),
                    x => x.HasOne(x => x.OrderDetail).WithMany().HasForeignKey(x => x.OrderDetailId));

            builder
                .HasMany(x => x.Products)
                .WithMany(x => x.OrderDetails)
                .UsingEntity<ProductOrderDetail>(
                    x => x.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId),
                    x => x.HasOne(x => x.OrderDetail).WithMany().HasForeignKey(x => x.OrderDetailId));
        }
    }
}