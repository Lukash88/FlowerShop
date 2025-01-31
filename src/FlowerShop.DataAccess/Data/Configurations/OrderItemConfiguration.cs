using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .Property(oi => oi.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(oi => oi.Quantity)
            .IsRequired();

        builder
            .OwnsOne(oi => oi.ItemOrdered, configPio =>
            {
                configPio.WithOwner();

                configPio.Property(pio => pio.ProductItemId)
                    .IsRequired();

                configPio.Property(pio => pio.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                configPio.Property(pio => pio.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(80000);
            });
    }
}