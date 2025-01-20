using FlowerShop.DataAccess.Core.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations;

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