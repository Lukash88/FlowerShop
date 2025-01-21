using FlowerShop.DataAccess.Data;
using DeliveryMethodEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.DeliveryMethod;

namespace FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;

public class AddDeliveryMethodCommand : CommandBase<DeliveryMethodEntity, DeliveryMethodEntity>
{
    public override async Task<DeliveryMethodEntity> Execute(FlowerShopStorageContext context)
    {
        await context.DeliveryMethods.AddAsync(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}