using FlowerShop.DataAccess.Core.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForOrder : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Order>(o => o.OrderState)
               .CanSort()
               .CanFilter(); ;

            mapper.Property<Order>(o => o.IsPaymentConfirmed)
                .CanSort()
                .CanFilter();
        }
    }
}