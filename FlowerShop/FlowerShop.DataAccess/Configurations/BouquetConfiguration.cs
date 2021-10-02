using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.Configurations
{
    public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
    {
        public void Configure(EntityTypeBuilder<Bouquet> builder)
        {
            builder
                .Property(x => x.Occasion)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
