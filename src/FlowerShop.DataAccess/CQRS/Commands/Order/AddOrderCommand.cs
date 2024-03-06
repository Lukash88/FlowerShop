using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    public class AddOrderCommand : CommandBase<Core.Entities.OrderAggregate.Order, Core.Entities.OrderAggregate.Order>
    {
        public override async Task<Core.Entities.OrderAggregate.Order> Execute(FlowerShopStorageContext context)
        {
            await context.Orders.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}