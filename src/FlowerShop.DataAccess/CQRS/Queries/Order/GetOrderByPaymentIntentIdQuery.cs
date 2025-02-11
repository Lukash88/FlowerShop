using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.DataAccess.CQRS.Queries.Order;

public sealed class GetOrderByPaymentIntentIdQuery : QueryBase<OrderEntity>
{
    public required string Id { get; init; }

    public override async Task<OrderEntity> Execute(FlowerShopStorageContext context)
        => await context.Orders
            .Include(x => x.OrderItems)
            .Include(x => x.DeliveryMethod)
            .Include(x => x.Reservations)
            .FirstOrDefaultAsync(x => x.PaymentIntentId == Id);
}