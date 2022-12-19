namespace FlowerShop.DataAccess.CQRS.Queries.DecorationOrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
   
    public class GetDecorationOrderDetailQuery : QueryBaseWithSieve<List<DecorationOrderDetail>>
    {
        public int DecorationId { get; init; }
        public int OrderDetailId { get; init; }
        public SieveModel SieveModel { get; init; }

        public async override Task<List<DecorationOrderDetail>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor) =>
            await sieveProcessor.Apply(SieveModel, context.DecorationOrderDetails.AsNoTracking()).ToListAsync();
    }
}