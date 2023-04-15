using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class BouquetOrderDetailConfiguration : IEntityTypeConfiguration<BouquetOrderDetail>
    {
        public void Configure(EntityTypeBuilder<BouquetOrderDetail> builder)
        {
            builder
                .ToTable("BouquetsOrderDetails");            
        }
    }
}