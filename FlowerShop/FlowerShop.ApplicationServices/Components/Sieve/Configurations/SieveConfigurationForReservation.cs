using FlowerShop.DataAccess.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForReservation : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Reservation>(r => r.DateOfEvent)
               .CanSort()
               .CanFilter(); ;

            mapper.Property<Reservation>(r => r.EventType)
                .CanSort()
                .CanFilter();

            mapper.Property<Reservation>(r => r.ReservationStatus)
                .CanSort()
                .CanFilter();
        }
    }
}
