using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod
{
    public class AddDeliveryMethodCommand : CommandBase<Core.Entities.OrderAggregate.DeliveryMethod,
        Core.Entities.OrderAggregate.DeliveryMethod>
    {
        public override async Task<Core.Entities.OrderAggregate.DeliveryMethod> Execute(FlowerShopStorageContext context)
        {
            await context.DeliveryMethods.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}