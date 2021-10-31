namespace FlowerShop.DataAccess.CQRS.Commands.OrderItem
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateOrderItemCommand : CommandBase<OrderItem, OrderItem>
    {
        public override async Task<OrderItem> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrderItems.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
