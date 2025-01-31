using FlowerShop.DataAccess.Data;
using DeliveryMethodEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.DeliveryMethod;

namespace FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;

public class RemoveDeliveryMethodCommand : CommandBase<DeliveryMethodEntity, DeliveryMethodEntity>
{
    public override async Task<DeliveryMethodEntity> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.DeliveryMethods.Remove(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}