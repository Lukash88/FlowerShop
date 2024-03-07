using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod
{
    public class UpdateDeliveryMethodCommand : CommandBase<Core.Entities.OrderAggregate.DeliveryMethod,
        Core.Entities.OrderAggregate.DeliveryMethod>
    {
        public override async Task<Core.Entities.OrderAggregate.DeliveryMethod> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.DeliveryMethods.Update(Parameter);
            await context.SaveChangesAsync();

            return Parameter;
        }
    }
}