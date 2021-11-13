namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
    using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOrderItemHandler : IRequestHandler<AddOrderItemRequest, AddOrderItemResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderItemHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderItemResponse> Handle(AddOrderItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemsQuery();
            var getAllOrderItems = await this.queryExecutor.Execute(query);
            var orderItem = this.mapper.Map<OrderItem>(request);
            var command = new AddOrderItemCommand()
            {
                Parameter = orderItem
            };
            if (command == null)
            {
                return new AddOrderItemResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            if (getAllOrderItems.Select(x => x.OrderDetailId).Contains(command.Parameter.OrderDetailId))
            {
                return new AddOrderItemResponse()
                {
                    Error = new ErrorModel(ErrorType.ValidationError)
                };
            }

            var addedOrderItem = await this.commandExecutor.Execute(command);
            var response = new AddOrderItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderItemDTO>(addedOrderItem)
            };

            return response;
        }
    }
}
