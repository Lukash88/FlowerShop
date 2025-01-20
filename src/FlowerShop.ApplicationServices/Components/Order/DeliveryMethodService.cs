using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class DeliveryMethodService(IQueryExecutor queryExecutor) : IDeliveryMethodService
{
    public async Task<DeliveryMethod> GetDeliveryMethod(int id)
    {
        return await queryExecutor.Execute(new GetDeliveryMethodQuery { Id = id });
    }
}