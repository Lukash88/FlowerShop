namespace FlowerShop.DataAccess.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class BouquetOrderDetailConfiguration : IEntityTypeConfiguration<BouquetOrderDetail>
    {
        public void Configure(EntityTypeBuilder<BouquetOrderDetail> builder)
        {
            builder
                .ToTable("BouquetsOrderDetails");            
        }
    }
}