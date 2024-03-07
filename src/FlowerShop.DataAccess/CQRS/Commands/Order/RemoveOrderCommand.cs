using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    public class RemoveOrderCommand : CommandBase<Core.Entities.OrderAggregate.Order, Core.Entities.OrderAggregate.Order>
    {
        public override async Task<Core.Entities.OrderAggregate.Order> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Orders.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}