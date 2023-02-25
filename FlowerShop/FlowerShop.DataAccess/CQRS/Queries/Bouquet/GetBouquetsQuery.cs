using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetBouquetsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Bouquet>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<Core.Entities.Bouquet>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = context.Bouquets.Include(x => x.Flowers).AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}