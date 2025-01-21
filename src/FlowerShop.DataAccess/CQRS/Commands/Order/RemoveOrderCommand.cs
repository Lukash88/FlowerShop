using FlowerShop.DataAccess.Data;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.DataAccess.CQRS.Commands.Order;

public class RemoveOrderCommand : CommandBase<OrderEntity, OrderEntity>
{
    public override async Task<OrderEntity> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Orders.Remove(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}