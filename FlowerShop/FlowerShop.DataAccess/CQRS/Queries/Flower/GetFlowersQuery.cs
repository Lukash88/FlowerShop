namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetFlowersQuery : QueryBaseWithSieve<List<Flower>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<List<Flower>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.Flowers.AsNoTracking());

            var avgPrice = Math.Round(query.Average(x => x.Price.Value), 2);

            return await query.ToListAsync();
        }
    }
}