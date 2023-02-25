using FlowerShop.DataAccess.Core.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForProduct : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Product>(p => p.Name)
                .CanSort()
                .CanFilter();

            mapper.Property<Product>(p => p.Price)
                .CanSort()
                .CanFilter();

            mapper.Property<Product>(p => p.Category)
                .CanSort()
                .CanFilter();

            //return mapper;
        }
    }
}
