using FlowerShop.DataAccess.Core.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForFlower : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Flower>(f => f.Name)
               .CanSort()
               .CanFilter();

            mapper.Property<Flower>(f => f.FlowerType)
                .CanSort()
                .CanFilter();

            mapper.Property<Flower>(f => f.Color)
               .CanSort()
               .CanFilter();

            mapper.Property<Flower>(f => f.Price)
                .CanSort()
                .CanFilter();
        }
    }
}