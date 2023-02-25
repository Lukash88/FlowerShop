using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Product
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetProductsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Product>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<Core.Entities.Product>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor)
        {
            var query = context.Products.AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}