namespace FlowerShop.DataAccess.CQRS.Queries.BouquetFlower
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetBouquetsFlowersQuery : QueryBaseWithSieve<List<BouquetFlower>>
    {
        public SieveModel SieveModel { get; init; }
        public async override Task<List<BouquetFlower>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.BouquetFlowers.AsNoTracking());

            return await query.ToListAsync();
        }
    }
}