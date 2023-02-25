using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.DecorationOrderDetail
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
   
    public class GetDecorationOrderDetailQuery : QueryBaseWithSieve<List<Core.Entities.DecorationOrderDetail>>
    {
        public int DecorationId { get; init; }
        public int OrderDetailId { get; init; }
        public SieveModel SieveModel { get; init; }

        public async override Task<List<Core.Entities.DecorationOrderDetail>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor) =>
            await sieveProcessor.Apply(SieveModel, context.DecorationOrderDetails.AsNoTracking()).ToListAsync();
    }
}