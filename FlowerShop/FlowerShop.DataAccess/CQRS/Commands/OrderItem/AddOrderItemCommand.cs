namespace FlowerShop.DataAccess.CQRS.Commands.OrderItem
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddOrderItemCommand : CommandBase<OrderItem, OrderItem>
    {
        public override async Task<OrderItem> Execute(FlowerShopStorageContext context)
        {
            await context.OrderItems.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}