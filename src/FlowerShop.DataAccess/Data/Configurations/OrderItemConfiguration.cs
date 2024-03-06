using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
               .Property(x => x.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            builder
                .Property(x => x.Quantity)
                .IsRequired();

            builder
                .OwnsOne(i => i.ItemOrdered, io =>
                {
                    io.WithOwner();
                });
        }
    }
}