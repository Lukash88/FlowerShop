using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Product
{
    public class GetProductsQuery : QueryBaseWithSieve<IQueryable<Entities.Product>>
    //public class GetProductsQuery : QueryBaseWithSieve<List<Entities.Product>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<Entities.Product>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        //public async override Task<List<Entities.Product>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.Products.AsNoTracking());

            return await Task.FromResult(query);
            //return await query.ToListAsync();
        }
    }
}