using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations;

public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation> 
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
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
            .Property(r => r.EventStreet)                                  
            .IsRequired()                                                  
            .HasMaxLength(50);                                             
                                                                            
        builder
            .Property(r => r.EventCity)                                    
            .IsRequired()                                                  
            .HasMaxLength(50);                                             
                                                                            
        builder
            .Property(r => r.EventPostalCode)                              
            .IsRequired()                                                      
            .HasMaxLength(20);

        builder
            .Property(r => r.ServicePrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired(false);
    }
}