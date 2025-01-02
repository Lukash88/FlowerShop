using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;

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
                var newOrder = await _orderService.ProcessOrderRequest(request);
                var orderDto = _mapper.Map<OrderToReturnDto>(newOrder);

                return new AddOrderResponse
                {
                    Data = orderDto
                };
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