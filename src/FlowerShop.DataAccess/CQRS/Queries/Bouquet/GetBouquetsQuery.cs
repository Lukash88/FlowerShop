using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    public class GetBouquetsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Bouquet>>
    {
        public SieveModel SieveModel { get; init; }

        public override async Task<IQueryable<Core.Entities.Bouquet>> Execute(FlowerShopStorageContext context,
            ISieveProcessor sieveProcessor)
        {
            var query = context.Bouquets
                .Include(x => x.Flowers)
                .AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}