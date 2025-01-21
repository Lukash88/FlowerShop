using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using OrderItemEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.OrderItem;

namespace FlowerShop.DataAccess.CQRS.Queries.OrderItem;

public sealed class GetOrderItemsQuery : QueryBase<List<OrderItemEntity>>
{
    public required int OrderId { get; init; }

    public override async Task<List<OrderItemEntity>> Execute(FlowerShopStorageContext context)
        => await context.Orders
            .Where(o => o.Id == OrderId)
            .Include(o => o.OrderItems)
            .SelectMany(o => o.OrderItems)
            .ToListAsync();
}