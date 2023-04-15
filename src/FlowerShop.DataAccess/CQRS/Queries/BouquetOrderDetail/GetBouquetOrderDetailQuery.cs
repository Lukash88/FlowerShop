using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.BouquetOrderDetail
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class GetBouquetOrderDetailQuery : QueryBaseWithSieve<List<Core.Entities.BouquetOrderDetail>>
    {
        public int BouquetId { get; init; }
        public int OrderDetailId { get; init; }
        public SieveModel SieveModel { get; init; }
        public async override Task<List<Core.Entities.BouquetOrderDetail>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor) =>
            await sieveProcessor.Apply(SieveModel, context.BouquetOrderDetails.AsNoTracking()).ToListAsync();
    }
}