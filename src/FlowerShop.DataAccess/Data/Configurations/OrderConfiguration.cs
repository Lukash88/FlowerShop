using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .Property(o => o.BuyerEmail)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(o => o.CreatedAt)
            .HasDefaultValueSql("getdate()")
            .HasConversion(
                od => od.ToUniversalTime(),
                od => DateTime.SpecifyKind(od, DateTimeKind.Utc)
            );

        builder
            .OwnsOne(o => o.ShippingAddress, a =>
            {
                a.WithOwner();

                a
                    .Property(a => a.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                a
                    .Property(a => a.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                a
                    .Property(a => a.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                a
                    .Property(a => a.City)
                    .IsRequired()
                    .HasMaxLength(50);

                a
                    .Property(a => a.PostalCode)
                    .IsRequired()
                    .HasMaxLength(20);
            });

        builder
            .Navigation(o => o.ShippingAddress)
            .IsRequired();

        builder
            .Property(o => o.Subtotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .Property(o => o.OrderState)
            .HasConversion(
                os => os.ToString(),
                os => Enum.Parse<OrderState>(os))
            .IsRequired();

        builder
            .Property(o => o.Invoice)
            .HasMaxLength(500)
            .IsRequired(false);

        builder
            .Property(o => o.PaymentIntentId)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasMany(o => o.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}