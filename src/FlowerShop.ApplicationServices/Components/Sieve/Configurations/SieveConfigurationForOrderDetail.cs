using FlowerShop.DataAccess.Core.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForOrderDetail : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<OrderDetail>(od => od.Name)
               .CanSort()
               .CanFilter(); ;

            mapper.Property<OrderDetail>(od => od.Category)
                .CanSort()
                .CanFilter();

            mapper.Property<OrderDetail>(od => od.Price)
                .CanSort()
                .CanFilter();
        }
    }
}