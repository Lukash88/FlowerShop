using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrdersQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Order>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<Core.Entities.Order>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = context.Orders
                .Include(x => x.OrderDetails)
                .Include(x  => x.Reservations)
                .AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}