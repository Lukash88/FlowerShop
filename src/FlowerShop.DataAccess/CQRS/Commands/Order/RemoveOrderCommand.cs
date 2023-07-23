using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    using System.Threading.Tasks;

    public class RemoveOrderCommand : CommandBase<Core.Entities.Order, Core.Entities.Order>
    {
        public override async Task<Core.Entities.Order> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Orders.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}