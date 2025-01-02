using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod
{
    public class AddDeliveryMethodCommand : CommandBase<Core.Entities.OrderAggregate.DeliveryMethod,
        Core.Entities.OrderAggregate.DeliveryMethod>
    {
        public override async Task<Core.Entities.OrderAggregate.DeliveryMethod> Execute(FlowerShopStorageContext context)
        {
            await context.DeliveryMethods.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}