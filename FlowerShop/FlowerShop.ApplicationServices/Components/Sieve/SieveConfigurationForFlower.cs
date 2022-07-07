using FlowerShop.DataAccess.Entities;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Sieve
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

            mapper.Property<Flower>(f => f.Colour)
               .CanSort()
               .CanFilter();

            mapper.Property<Flower>(f => f.Price)
                .CanSort()
                .CanFilter();
        }
    }
}
