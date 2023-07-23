using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.BouquetFlower
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetBouquetFlowerQuery : QueryBaseWithSieve<List<Core.Entities.BouquetFlower>>
    {
        public int BouquetId { get; init; }
        public int FlowerId { get; init; }
        public SieveModel SieveModel { get; init; }

        public override async Task<List<Core.Entities.BouquetFlower>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor) =>
            await sieveProcessor.Apply(SieveModel, context.BouquetFlowers.AsNoTracking()).ToListAsync();
    }
}