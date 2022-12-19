namespace FlowerShop.DataAccess.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductOrderDetailConfiguration : IEntityTypeConfiguration<ProductOrderDetail>
    {
        public void Configure(EntityTypeBuilder<ProductOrderDetail> builder)
        {
            builder
               .ToTable("ProductsOrderDetails");
        }
    }
}