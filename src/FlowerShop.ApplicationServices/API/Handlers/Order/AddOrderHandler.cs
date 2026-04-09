using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.Order;

public class AddOrderHandler(IOrderService orderService, IMapper mapper, ILogger<AddOrderHandler> logger)
    : IRequestHandler<AddOrderRequest, AddOrderResponse>
{
    public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("AddOrderHandler started for CartId: {CartId}, BuyerEmail: {BuyerEmail}",
            request.CartId, request.BuyerEmail);

        try
        {
            logger.LogInformation("Processing order request. DeliveryMethodId: {DeliveryMethodId}, Discount: {Discount}",
                request.DeliveryMethodId, request.Discount);

            var newOrder = await orderService.ProcessOrderRequest(request);

            logger.LogInformation("Order created/retrieved successfully. OrderId: {OrderId}, State: {State}, PaymentIntentId: {PaymentIntentId}",
                newOrder.Id, newOrder.OrderState, newOrder.PaymentIntentId);

            var orderDto = mapper.Map<OrderToReturnDto>(newOrder);

            return new AddOrderResponse
            {
                Data = orderDto
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating order for CartId {CartId}: {Message}\nStackTrace: {StackTrace}",
                request.CartId, ex.Message, ex.StackTrace);

            return new AddOrderResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem creating order. " + ex.Message)
            };
        }
    }
}