namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using DataAccess.Entities;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
    using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateOrderItemHandler : IRequestHandler<UpdateOrderItemRequest, UpdateOrderItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateOrderItemHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {        
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateOrderItemResponse> Handle(UpdateOrderItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemQuery()
            {
                Id = request.OrderItemId
            };
            var getOrderItem = await this.queryExecutor.Execute(query);
            if (getOrderItem == null)
            {
                return new UpdateOrderItemResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrderItem = this.mapper.Map<OrderItem>(request);
            var command = new UpdateOrderItemCommand()
            {
                Parameter = mappedOrderItem
            };
            if (command == null)
            {
                return new UpdateOrderItemResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var getAllQuery = new GetOrderItemsQuery();
            var getAllOrderItems = await this.queryExecutor.Execute(getAllQuery);
            if (getAllOrderItems.Select(x => x.OrderDetailId).Contains(command.Parameter.OrderDetailId))
            {
                return new UpdateOrderItemResponse()
                {
                    Error = new ErrorModel(ErrorType.ValidationError)
                };
            }

            var updatedOrderItem = await this.commandExecutor.Execute(command);
            var response =  new UpdateOrderItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderItemDTO>(updatedOrderItem)
            };

            return response;
        }
    }
}
