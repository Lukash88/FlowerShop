namespace FlowerShop.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation> 
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
             .Property(x => x.ReservationStatus)                            
             .IsRequired();

            builder                                                         
             .Property(x => x.DateOfEvent)                                  
             .IsRequired();      
                                                                            
            builder
             .Property(x => x.ReservedOn)                                   
             .IsRequired();                                                 
                                                                            
            builder                                                         
             .Property(x => x.EventType)                                    
             .IsRequired()                                                  
             .HasMaxLength(50);                                             
                                                                            
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
        }
    }
}