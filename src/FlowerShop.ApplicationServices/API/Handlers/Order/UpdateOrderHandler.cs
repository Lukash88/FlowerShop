using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Order;

public class UpdateOrderHandler(IMapper mapper, IOrderService orderService)
    : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
{
    public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var updatedOrder = await orderService.ProcessUpdateOrderRequest(request);
            var orderDto = mapper.Map<OrderToReturnDto>(updatedOrder);

            return new UpdateOrderResponse
            {
                Data = orderDto
            };
        }
        catch (Exception ex)
        {
            // TODO: Log the exception
            return new UpdateOrderResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating order. " + ex.Message)
            };
        }
    }
}