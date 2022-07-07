using FlowerShop.DataAccess.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve
{
    public class SieveConfigurationForOrder : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Order>(o => o.OrderState)
               .CanSort()
               .CanFilter();;

            mapper.Property<Order>(o => o.IsPaymentConfirmed)
                .CanSort()
                .CanFilter();
        }    
    }
}
