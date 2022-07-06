namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetBouquetsQuery : QueryBaseWithSieve<List<Bouquet>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<List<Bouquet>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.Bouquets.AsNoTracking());

            return await query.ToListAsync(); ;
        }
    }
}