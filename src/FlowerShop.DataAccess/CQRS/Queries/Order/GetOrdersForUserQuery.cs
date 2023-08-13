using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    public class GetOrdersForUserQuery : QueryBaseWithSieve<IQueryable<Core.Entities.OrderAggregate.Order>>
    {
        public SieveModel SieveModel { get; init; }
        public string Email { get; init; }

        public override async Task<IQueryable<Core.Entities.OrderAggregate.Order>> Execute(
            FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = context.Orders
                .Where(x => x.BuyerEmail == Email)
                .Include(x => x.OrderItems)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.Reservations)
                .AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}