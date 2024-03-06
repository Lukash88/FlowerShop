using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForDeliveryMethods : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<DeliveryMethod>(dm => dm.Price)
                .CanSort()
                .CanFilter();

            mapper.Property<DeliveryMethod>(dm => dm.DeliveryTime)
                .CanSort()
                .CanFilter();

            mapper.Property<DeliveryMethod>(dm => dm.ShortName)
                .CanSort()
                .CanFilter();
        }
    }
}