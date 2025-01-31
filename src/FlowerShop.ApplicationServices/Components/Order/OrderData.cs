using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderData(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor) : IOrderData
{
    public async Task<OrderEntity> GetOrder(string paymentIntentId)
    {
        var getOrderQuery = new GetOrderByPaymentIntentIdQuery
        {
            Id = paymentIntentId
        };

        return await queryExecutor.Execute(getOrderQuery);
    }

    public async Task<OrderEntity> CreateOrder(OrderEntity order)
    {
        var addOrderCommand = new AddOrderCommand
        {
            Parameter = order
        };

        return await commandExecutor.Execute(addOrderCommand);
    }

    public async Task<OrderEntity> UpdateOrder(OrderEntity order)
    {
        var updateOrderCommand = new UpdateOrderCommand
        {
            Parameter = order
        };

        return await commandExecutor.Execute(updateOrderCommand);
    }
}