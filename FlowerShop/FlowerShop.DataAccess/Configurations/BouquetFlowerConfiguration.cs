using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Configurations
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
