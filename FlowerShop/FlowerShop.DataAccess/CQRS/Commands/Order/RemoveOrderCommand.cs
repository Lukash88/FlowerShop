namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class RemoveOrderCommand : CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Orders.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}