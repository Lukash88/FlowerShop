using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Identity.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.LastName)
            .IsRequired()
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

        builder
            .Property(x => x.AppUserId)
            .IsRequired();
    }
}