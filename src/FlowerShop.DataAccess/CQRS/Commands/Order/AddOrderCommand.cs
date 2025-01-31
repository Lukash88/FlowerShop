using FlowerShop.DataAccess.Data;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.DataAccess.CQRS.Commands.Order;

public class AddOrderCommand : CommandBase<OrderEntity, OrderEntity>
{
    public override async Task<OrderEntity> Execute(FlowerShopStorageContext context)
    {
        await context.Orders.AddAsync(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}