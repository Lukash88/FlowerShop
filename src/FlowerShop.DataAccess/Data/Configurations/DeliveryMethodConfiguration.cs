using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public sealed class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder
                .Property(dm => dm.ShortName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(dm => dm.DeliveryTime)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(dm => dm.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(dm => dm.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}