using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public UpdateOrderHandler(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedOrder = await _orderService.ProcessUpdateOrderRequest(request);
                var orderDto = _mapper.Map<OrderToReturnDto>(updatedOrder);

                return new UpdateOrderResponse()
                {
                    Data = orderDto
                };
            }
            catch (Exception ex)
            {
                // TODO: Log the exception
                return new UpdateOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating order. " + ex.Message)
                };
            }
        }
    }
}