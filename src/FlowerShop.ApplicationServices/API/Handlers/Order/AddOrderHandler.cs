using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class AddOrderHandler  : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IBasketRepository basketRepository;
        private readonly IOrderService orderService;

        public AddOrderHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor, 
            IBasketRepository basketRepository, IOrderService orderService)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.basketRepository = basketRepository;
            this.orderService = orderService;
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            // get items from the product repo  
            var items = await this.orderService.GetOrderItems(request.BasketId);

            // get delivery method from the repo
            var deliveryMethod = await this.orderService.GetDeliveryMethod(request.DeliveryMethodId);

            // calculate subtotal
            var subtotal = this.orderService.GetSubtotal(items);

            // create order
            var order = this.mapper.Map<DataAccess.Core.Entities.OrderAggregate.Order>(request);
            var addedOrder = await this.orderService.CreateOrder(order, deliveryMethod, items, subtotal, request.BuyerEmail,
                request.ShipToAddress);
            if (addedOrder is null)
            {
                return new AddOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem creating order")
                };
            }

            var response = new AddOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderToReturnDto>(addedOrder)
            };

            return response;
        }
    }
}