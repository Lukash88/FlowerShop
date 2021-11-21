namespace FlowerShop.DataAccess.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {      
            builder
                .Property(x => x.IsPaymentConfirmed)
                .IsRequired();                
           
             builder                                                
                .Property(x => x.CreatedAt)                             
                .IsRequired(false);                                          
            
             builder
                .Property(x => x.OrderState)
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