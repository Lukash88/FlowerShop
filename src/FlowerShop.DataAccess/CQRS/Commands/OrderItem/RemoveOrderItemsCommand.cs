using FlowerShop.DataAccess.Data;
using OrderItemEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.OrderItem;

namespace FlowerShop.DataAccess.CQRS.Commands.OrderItem
{
    public sealed class RemoveOrderItemsCommand : CommandBase<List<OrderItemEntity>, List<OrderItemEntity>>
    {
        public override async Task<List<OrderItemEntity>> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrderItems.RemoveRange(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}