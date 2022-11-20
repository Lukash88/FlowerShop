namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrderDetailsQuery : QueryBaseWithSieve<IQueryable<OrderDetail>>
    {
        public SieveModel SieveModel { get; init; }

        public override async Task<IQueryable<OrderDetail>> Execute(FlowerShopStorageContext context, 
            ISieveProcessor sieveProcessor)
        {
            var query = context.OrderDetails
                .Include(x => x.Bouquets)
                .Include(x => x.Decorations)
                .Include(x => x.Products)
                .AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}