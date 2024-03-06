using System;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation> 
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
             .Property(x => x.ReservationStatus)
             .HasConversion(
                 rs => rs.ToString(),
                 rs => (ReservationStateEnum)Enum.Parse(typeof(ReservationStateEnum), rs))
             .IsRequired();

            builder                                                         
             .Property(x => x.DateOfEvent)                                  
             .IsRequired();      
                                                                            
            builder
             .Property(x => x.ReservedOn)                                   
             .IsRequired()
             .HasDefaultValueSql("getdate()");                                                 
                                                                            
            builder                                                         
             .Property(x => x.EventType)
             .HasConversion(
                 et => et.ToString(), 
                 et => (EventType)Enum.Parse(typeof(EventType), et))
             .IsRequired();                                             
                                                                            
            builder                                                         
             .Property(x => x.EventDescription)                             
             .IsRequired()                                                  
             .HasMaxLength(500);                                            
                                                                            
            builder                                                         
             .Property(x => x.EventStreet)                                  
             .IsRequired()                                                  
             .HasMaxLength(50);                                             
                                                                            
            builder                                                         
             .Property(x => x.EventCity)                                    
             .IsRequired()                                                  
             .HasMaxLength(50);                                             
                                                                            
            builder                                                         
             .Property(x => x.EventPostalCode)                              
             .IsRequired()                                                      
             .HasMaxLength(20);

            builder
               .Property(x => x.ServicePrice)
               //.HasColumnType("decimal(18,2)")
               .HasPrecision(14, 2)
               .IsRequired(false);
        }
    }
}