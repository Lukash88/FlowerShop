using FlowerShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FlowerShop.Configurations
{
    public class ReservationStateConfiguration : IEntityTypeConfiguration<ReservationState>
    {
        public void Configure(EntityTypeBuilder<ReservationState> builder)
        {
            builder
                .Property(x => x.ReservationStatus)
                .IsRequired();
        }
    }
}
