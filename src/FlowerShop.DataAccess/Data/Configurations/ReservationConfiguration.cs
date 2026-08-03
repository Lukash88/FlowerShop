using FlowerShop.DataAccess.Core.Entities.ReservationAggregate;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations;

public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .Property(r => r.Email)
            .IsRequired()
            .HasMaxLength(254);

        builder
            .Property(r => r.ReservationStatus)
            .HasConversion(
                rs => rs.ToString(),
                rs => Enum.Parse<ReservationState>(rs))
            .IsRequired();

        builder
            .Property(r => r.DateOfEvent)
            .IsRequired();

        builder
            .Property(r => r.ReservedOn)
            .IsRequired()
            .HasDefaultValueSql("getdate()");

        builder
            .Property(r => r.EventType)
            .HasConversion(
                et => et.ToString(),
                et => Enum.Parse<EventType>(et))
            .IsRequired();

        builder
            .Property(r => r.EventDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder
            .Property(r => r.ServicePrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);

        builder.OwnsOne(r => r.EventAddress, a =>
        {
            a
                .Property(x => x.Line1)
                .HasColumnName("EventLine1").IsRequired()
                .HasMaxLength(100);

            a
                .Property(x => x.Line2)
                .HasColumnName("EventLine2")
                .HasMaxLength(100);

            a
                .Property(x => x.City)
                .HasColumnName("EventCity")
                .IsRequired()
                .HasMaxLength(50);

            a
                .Property(x => x.State)
                .HasColumnName("EventState")
                .IsRequired()
                .HasMaxLength(50);

            a
                .Property(x => x.PostalCode)
                .HasColumnName("EventPostalCode")
                .IsRequired()
                .HasMaxLength(20);

            a
                .Property(x => x.Country)
                .HasColumnName("EventCountry")
                .IsRequired()
                .HasMaxLength(70);
        });
    }
}