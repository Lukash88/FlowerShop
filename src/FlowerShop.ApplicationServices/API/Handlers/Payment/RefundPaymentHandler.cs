using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Payment;
using FlowerShop.DataAccess.Core.Enums;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.API.Handlers.Payment;

public sealed class RefundPaymentForOrderHandler(
    IPaymentService paymentService,
    IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor,
    IMapper mapper,
    ILogger<RefundPaymentForOrderHandler> logger)
    : IRequestHandler<RefundPaymentForOrderRequest, RefundPaymentForOrderResponse>
{
    public async Task<RefundPaymentForOrderResponse> Handle(
        RefundPaymentForOrderRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing refund for order ID: {OrderId}", request.Id);

        try
        {
            var query = new GetOrderQuery
            {
                Id = request.Id
            };

            var order = await queryExecutor.Execute(query);
            if (order is null)
            {
                logger.LogWarning("Order not found with ID: {OrderId}", request.Id);
                return new RefundPaymentForOrderResponse
                {
                    Error = new ErrorModel($"{ErrorType.BadRequest} - Order with that ID was not found")
                };
            }

            logger.LogInformation("Order found. State: {OrderState}, PaymentIntentId: {PaymentIntentId}",
                order.OrderState, order.PaymentIntentId);

            if (order.OrderState == OrderState.Pending)
            {
                logger.LogWarning("Cannot refund pending order: {OrderId}", request.Id);
                return new RefundPaymentForOrderResponse
                {
                    Error = new ErrorModel($"{ErrorType.BadRequest} - Cannot refund a pending order")
                };
            }

            if (order.OrderState == OrderState.Refunded)
            {
                logger.LogWarning("Order already refunded: {OrderId}", request.Id);
                return new RefundPaymentForOrderResponse
                {
                    Error = new ErrorModel($"{ErrorType.BadRequest} - Order has already been refunded")
                };
            }

            logger.LogInformation("Initiating Stripe refund for PaymentIntentId: {PaymentIntentId}",
                order.PaymentIntentId);

            var result = await paymentService.RefundPayment(order.PaymentIntentId);

            logger.LogInformation("Stripe refund result: {Result}", result);

            if (result == "succeeded")
            {
                var updatedOrder = new OrderEntity
                {
                    Id = order.Id,
                    BuyerEmail = order.BuyerEmail,
                    CreatedAt = order.CreatedAt,
                    ShippingAddress = order.ShippingAddress,
                    DeliveryMethod = order.DeliveryMethod,
                    PaymentSummary = order.PaymentSummary,
                    Subtotal = order.Subtotal,
                    Discount = order.Discount,
                    OrderState = OrderState.Refunded,
                    Invoice = order.Invoice,
                    PaymentIntentId = order.PaymentIntentId,
                    OrderItems = order.OrderItems,
                    Reservations = order.Reservations
                };

                var updateOrderCommand = new UpdateOrderCommand()
                {
                    Parameter = updatedOrder
                };

                var command = await commandExecutor.Execute(updateOrderCommand);
                var orderDto = mapper.Map<OrderToReturnDto>(command);

                logger.LogInformation("Order {OrderId} successfully refunded and updated to Refunded state",
                    request.Id);

                return new RefundPaymentForOrderResponse
                {
                    Data = orderDto
                };
            }

            logger.LogError("Stripe refund failed for order {OrderId}. Result: {Result}",
                request.Id, result);

            return new RefundPaymentForOrderResponse
            {
                Error = new ErrorModel($"{ErrorType.BadRequest} - Problem refunding order")
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception while processing refund for order {OrderId}: {Message}",
                request.Id, ex.Message);

            return new RefundPaymentForOrderResponse
            {
                Error = new ErrorModel($"{ErrorType.BadRequest} - {ex.Message}")
            };
        }
    }
}