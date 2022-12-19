namespace FlowerShop.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
    {
        public void Configure(EntityTypeBuilder<Bouquet> builder)
        {
            builder
                .Property(x => x.Occasion)
                .IsRequired();

            builder
                .Property(x => x.TypeOfArrangement)
                .IsRequired();

            builder
                .Property(x => x.DecorationWay)
                .IsRequired();

            builder
                .Property(x => x.StockLevel)
                .IsRequired();

            builder
                .HasMany(x => x.Flowers)
                .WithMany(x => x.Bouquets)
                .UsingEntity<BouquetFlower>(
                    x => x.HasOne(x => x.Flower).WithMany().HasForeignKey(x => x.FlowerId),
                    x => x.HasOne(x => x.Bouquet).WithMany().HasForeignKey(x => x.BouquetId));
        }
    }
}