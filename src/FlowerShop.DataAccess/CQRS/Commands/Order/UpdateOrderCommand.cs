using FlowerShop.DataAccess.Data;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.DataAccess.CQRS.Commands.Order;

public class UpdateOrderCommand : CommandBase<OrderEntity, OrderEntity>
{
    public override async Task<OrderEntity> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Orders.Update(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}