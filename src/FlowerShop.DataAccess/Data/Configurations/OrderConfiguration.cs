using System;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {      
            builder
                .Property(x => x.IsPaymentConfirmed)
                .IsRequired();

            builder
               .Property(x => x.Invoice)
               .HasMaxLength(500)
               .IsRequired(false);

            builder                                                
                .Property(x => x.CreatedAt)                             
                .IsRequired(false)
                .HasDefaultValueSql("getdate()");

            builder
                .Property(x => x.OrderState)
                .HasConversion(
                    os => os.ToString(),
                    os => (OrderState)Enum.Parse(typeof(OrderState), os))
                .IsRequired();

            builder
                .Property(x => x.Quantity)
                .IsRequired();

            builder
                .Property(x => x.Sum)
                .HasPrecision(14, 2)
                .IsRequired(false);

            builder
                .HasMany(x => x.OrderDetails)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }           
    }
}