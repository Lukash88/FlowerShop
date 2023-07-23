using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.ProductOrderDetail
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetProductOrderDetailQuery : QueryBaseWithSieve<List<Core.Entities.ProductOrderDetail>>
    {
        public int ProductId { get; init; }
        public int OrderDetailId { get; init; }
        public SieveModel SieveModel { get; init; }

        public async override Task<List<Core.Entities.ProductOrderDetail>> Execute(FlowerShopStorageContext context,
            ISieveProcessor sieveProcessor) =>
            await sieveProcessor.Apply(SieveModel, context.ProductOrderDetails.AsNoTracking()).ToListAsync();
    }
}