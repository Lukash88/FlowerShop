using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
            .Property(x => x.ProductQuantity)
            .IsRequired();

            builder
            .Property(x => x.CreatedAt)
            .IsRequired();

            builder
           .Property(x => x.OrderState)
           .IsRequired();
        }
    }
}