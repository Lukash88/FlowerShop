using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.Components.Sieve;

public class ApplicationSieveProcessor(IOptions<SieveOptions> options) : SieveProcessor(options)
{
    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        return mapper.ApplyConfigurationsFromAssembly(typeof(ApplicationSieveProcessor).Assembly);
    }
}