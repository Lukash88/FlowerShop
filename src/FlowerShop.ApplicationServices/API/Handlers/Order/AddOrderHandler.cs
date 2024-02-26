using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class AddOrderHandler : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public AddOrderHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _mapper.Map<OrderEntity>(request);
                var addedOrder = await _orderService.ProcessOrder(request, order);
                var orderDto = _mapper.Map<Domain.Models.OrderToReturnDto>(addedOrder);
                
                return new AddOrderResponse { Data = orderDto };
            }
            catch (Exception ex)
            {
                // TODO: Log the exception
                return new AddOrderResponse
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem creating order. " + ex.Message)
                };
            }
        }
    }
}