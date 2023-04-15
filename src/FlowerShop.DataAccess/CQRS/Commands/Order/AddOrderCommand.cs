using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Order
{
    using System.Threading.Tasks;

    public class AddOrderCommand : CommandBase<Core.Entities.Order, Core.Entities.Order>
    {
        public override async Task<Core.Entities.Order> Execute(FlowerShopStorageContext context)
        {
            await context.Orders.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}