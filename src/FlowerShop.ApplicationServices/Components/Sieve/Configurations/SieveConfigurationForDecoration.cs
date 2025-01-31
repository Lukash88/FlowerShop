using FlowerShop.DataAccess.Core.Entities;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations;

public class SieveConfigurationForDecoration : ISieveConfiguration
{
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<Decoration>(d => d.Name)
            .CanSort()
            .CanFilter();

        mapper.Property<Decoration>(d => d.Role)
            .CanSort()
            .CanFilter();

        mapper.Property<Decoration>(d => d.Price)
            .CanSort()
            .CanFilter();
    }
}