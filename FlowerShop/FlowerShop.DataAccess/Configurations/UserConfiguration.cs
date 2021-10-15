using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Roles)
                .IsRequired();

            builder
               .Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(x => x.SecondName)
               .IsRequired()
               .HasMaxLength(50);

            builder
              .Property(x => x.UserName)
              .HasMaxLength(50);

            builder
               .Property(x => x.Street)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(x => x.PostalCode)
               .IsRequired()
               .HasMaxLength(20);

            builder
               .Property(x => x.City)
               .IsRequired()
               .HasMaxLength(50);
        }
    }
}
