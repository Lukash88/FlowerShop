using FlowerShop.DataAccess.Entities;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForBouquet : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Bouquet>(b => b.Occasion)
                .CanSort()
                .CanFilter();

            mapper.Property<Bouquet>(p => p.TypeOfArrangement)
                .CanSort()
                .CanFilter();

            mapper.Property<Bouquet>(p => p.DecorationWay)
                .CanSort()
                .CanFilter();
        }

    }
}
