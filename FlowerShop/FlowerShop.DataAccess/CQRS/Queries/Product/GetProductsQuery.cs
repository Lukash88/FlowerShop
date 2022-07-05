namespace FlowerShop.DataAccess.CQRS.Queries.Product
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sieve.Services;
    using Sieve.Models;

    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<List<Product>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.Products.AsNoTracking());
            
            return await query.ToListAsync(); ;
        }
    }
}