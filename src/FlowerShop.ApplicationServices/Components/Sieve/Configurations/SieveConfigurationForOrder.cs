using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForOrder : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<DataAccess.Core.Entities.OrderAggregate.Order>(o => o.BuyerEmail)
                .CanSort()
                .CanFilter();

            mapper.Property<DataAccess.Core.Entities.OrderAggregate.Order>(o => o.CreatedAt)
                .CanSort()
                .CanFilter();

            mapper.Property<DataAccess.Core.Entities.OrderAggregate.Order>(o => o.OrderState)
                .CanSort()
                .CanFilter();
        }
    }
}