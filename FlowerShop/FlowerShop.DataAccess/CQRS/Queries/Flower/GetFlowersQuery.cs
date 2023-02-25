using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetFlowersQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Flower>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<Core.Entities.Flower>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = context.Flowers.AsNoTracking();

            var avgPrice = Math.Round(query.Average(x => x.Price.Value), 2);

            return await Task.FromResult(query);
        }
    }
}