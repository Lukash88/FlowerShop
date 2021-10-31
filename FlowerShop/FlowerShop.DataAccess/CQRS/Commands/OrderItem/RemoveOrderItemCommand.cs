namespace FlowerShop.DataAccess.CQRS.Commands.OrderItem
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class RemoveOrderItemCommand : CommandBase<OrderItem, OrderItem>
    {
        public override async Task<OrderItem> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrderItems.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}