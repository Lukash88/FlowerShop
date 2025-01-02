using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod
{
    public class RemoveDeliveryMethodCommand : CommandBase<Core.Entities.OrderAggregate.DeliveryMethod,
        Core.Entities.OrderAggregate.DeliveryMethod>
    {
        public override async Task<Core.Entities.OrderAggregate.DeliveryMethod> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.DeliveryMethods.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}