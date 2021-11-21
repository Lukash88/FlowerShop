namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddOrderCommand : CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(FlowerShopStorageContext context)
        {
            await context.Orders.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}