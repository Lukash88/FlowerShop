namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateOrderCommand : CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Orders.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}