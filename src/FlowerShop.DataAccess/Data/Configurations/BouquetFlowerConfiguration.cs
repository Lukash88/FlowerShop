using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class BouquetFlowerConfiguration : IEntityTypeConfiguration<BouquetFlower>
    {
        public void Configure(EntityTypeBuilder<BouquetFlower> builder)
        {
            builder
                .ToTable("BouquetsFlowers");
        }
    }
}
