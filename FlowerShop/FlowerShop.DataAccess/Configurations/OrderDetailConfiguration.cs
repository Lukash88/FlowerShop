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
        }
    }
}
