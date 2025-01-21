using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.DataAccess.CQRS.Queries.Order;

public sealed class GetOrderForUserQuery : QueryBase<OrderEntity>
{ 
    public required string Email { get; init; }
    public required int Id { get; init; }
        
    public override async Task<OrderEntity> Execute(FlowerShopStorageContext context)
        => await context.Orders
            .Where(x => x.BuyerEmail == Email)
            .Include(x => x.OrderItems)
            .Include(x => x.DeliveryMethod)
            .Include(x => x.Reservations)
            .FirstOrDefaultAsync(x => x.Id == Id);
}