using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Order;

public class GetOrdersQuery : QueryBaseWithSieve<IQueryable<Core.Entities.OrderAggregate.Order>>
{
    public SieveModel SieveModel { get; init; }

    public override async Task<IQueryable<Core.Entities.OrderAggregate.Order>> Execute(
        FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
    {
        var query = context.Orders
            .Include(x => x.OrderItems)
            .Include(x => x.DeliveryMethod)
            .Include(x => x.Reservations)
            .AsNoTracking();

        return await Task.FromResult(query);
    }
}