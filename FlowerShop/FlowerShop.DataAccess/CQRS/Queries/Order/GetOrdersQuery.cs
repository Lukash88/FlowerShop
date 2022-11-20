namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrdersQuery : QueryBaseWithSieve<IQueryable<Order>>
    {
        public SieveModel SieveModel { get; init; }

        public async override Task<IQueryable<Order>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = context.Orders
                .Include(x => x.OrderDetails)
                .Include(x  => x.Reservations)
                .AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}