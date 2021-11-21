namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Order;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOrderHandler : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersQuery();
            var getAllOrders = await this.queryExecutor.Execute(query);
            var order = this.mapper.Map<Order>(request);
            var command = new AddOrderCommand()
            {
                Parameter = order
            };
            if (command == null)
            {
                return new AddOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            //if (getAllOrderItems.Select(x => x.OrderDetailId).Contains(command.Parameter.OrderDetailId))                 //removed or renamed
            //{                                                                                                            //removed or renamed
            //    return new AddOrderItemResponse()                                                                        //removed or renamed
            //    {                                                                                                        //removed or renamed
            //        Error = new ErrorModel(ErrorType.ValidationError)                                                    //removed or renamed
            //    };                                                                                                       //removed or renamed
            //}

            var addedOrderItem = await this.commandExecutor.Execute(command);
            var response = new AddOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDTO>(addedOrderItem)
            };

            return response;
        }
    }
}
