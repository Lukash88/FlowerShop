using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder
              .Property(x => x.Description)
              .IsRequired()
              .HasMaxLength(200);

            builder
              .Property(x => x.Category)
              .IsRequired()
              .HasMaxLength(200);

            builder
               .Property(x => x.Price)
               .HasPrecision(14, 2)
               .IsRequired();
        }
    }
}