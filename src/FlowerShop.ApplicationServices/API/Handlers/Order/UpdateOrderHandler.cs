using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.Order;

public class UpdateOrderHandler(IMapper mapper, IOrderService orderService, ILogger<UpdateOrderHandler> logger)
    : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
{
    public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateOrderHandler started for OrderId: {OrderId}", request.Id);

        try
        {
            logger.LogInformation("Processing update order request...");
            var updatedOrder = await orderService.ProcessUpdateOrderRequest(request);
            
            logger.LogInformation("Order {OrderId} updated successfully. State: {State}", 
                updatedOrder.Id, updatedOrder.OrderState);

            var orderDto = mapper.Map<OrderToReturnDto>(updatedOrder);

            return new UpdateOrderResponse
            {
                Data = orderDto
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating order {OrderId}: {Message}\nStackTrace: {StackTrace}",
                request.Id, ex.Message, ex.StackTrace);

            return new UpdateOrderResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating order. " + ex.Message)
            };
        }
    }
}