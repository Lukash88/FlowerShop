using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    public class GetFlowersQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Flower>>
    {
        public SieveModel SieveModel { get; init; }

        public override async Task<IQueryable<Core.Entities.Flower>> Execute(FlowerShopStorageContext context,
            ISieveProcessor sieveProcessor)
        {
            var query = context.Flowers.AsNoTracking();

            var avgPrice = Math.Round(query.Average(x => x.Price), 2);

            return await Task.FromResult(query);
        }
    }
}