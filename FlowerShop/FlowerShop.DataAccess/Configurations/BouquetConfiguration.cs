﻿using FlowerShop.DataAccess.Entities;
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
                .IsRequired();

            builder
                .Property(x => x.TypeOfArrangement
                )
                .IsRequired();

            builder
                .Property(x => x.DecorationWay)
                .IsRequired();
            builder
                .Property(x => x.Quantity)
                .IsRequired();
    }
}
}
