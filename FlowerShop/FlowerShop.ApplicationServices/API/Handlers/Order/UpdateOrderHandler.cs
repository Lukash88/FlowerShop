namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using DataAccess.Entities;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Order;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {        
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery()
            {
                Id = request.OrderId
            };
            var getOrder = await this.queryExecutor.Execute(query);
            if (getOrder == null)
            {
                return new UpdateOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrder = this.mapper.Map<Order>(request);
            var command = new UpdateOrderCommand()
            {
                Parameter = mappedOrder
            };
            if (command == null)
            {
                return new UpdateOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var getAllQuery = new GetOrdersQuery();
            var getAllOrders = await this.queryExecutor.Execute(getAllQuery);
            //if (getAllOrderItems.Select(x => x.OrderDetailId).Contains(command.Parameter.OrderDetailId))
            //{                                                                                                                          //removed or renamed
            //    return new UpdateOrderItemResponse()                                                                                   //removed or renamed
            //    {                                                                                                                      //removed or renamed
            //        Error = new ErrorModel(ErrorType.ValidationError)                                                                  //removed or renamed
            //    };                                                                                                                     //removed or renamed
            //}                                                                                                                          //removed or renamed

            var updatedOrder = await this.commandExecutor.Execute(command);
            var response =  new UpdateOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDTO>(updatedOrder)
            };

            return response;
        }
    }
}
