using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Identity.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .Property(x => x.Line1)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Line2)
            .HasMaxLength(100);

        builder
            .Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.PostalCode)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(x => x.Country)
            .HasMaxLength(70)
            .IsRequired();

        builder
            .Property(x => x.AppUserId)
            .IsRequired();
    }
}