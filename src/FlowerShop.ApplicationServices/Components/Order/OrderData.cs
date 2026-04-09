using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using Microsoft.Extensions.Logging;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderData(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, ILogger<OrderData> logger) : IOrderData
{
    public async Task<OrderEntity> GetOrder(string paymentIntentId)
    {
        logger.LogInformation("GetOrder called with PaymentIntentId: {PaymentIntentId}", paymentIntentId);
    
        if (string.IsNullOrEmpty(paymentIntentId))
        {
            logger.LogWarning("PaymentIntentId is null or empty");
            return null;
    }


        var getOrderQuery = new GetOrderByPaymentIntentIdQuery
        {
            Id = paymentIntentId
        };

        var order = await queryExecutor.Execute(getOrderQuery);

         if (order is null)
    {
        logger.LogWarning("No order found with PaymentIntentId: {PaymentIntentId}", paymentIntentId);
    }
    else
    {
        logger.LogInformation("Found order {Id} for PaymentIntentId: {PaymentIntentId}", 
            order.Id, paymentIntentId);
    }


        return order;
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