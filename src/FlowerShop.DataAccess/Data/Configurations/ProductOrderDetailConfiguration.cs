using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class ProductOrderDetailConfiguration : IEntityTypeConfiguration<ProductOrderDetail>
    {
        public void Configure(EntityTypeBuilder<ProductOrderDetail> builder)
        {
            builder
               .ToTable("ProductsOrderDetails");
        }
    }
}