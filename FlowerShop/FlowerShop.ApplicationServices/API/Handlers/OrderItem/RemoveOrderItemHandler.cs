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
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveOrderItemHandler : IRequestHandler<RemoveOrderItemRequest, RemoveOrderItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public RemoveOrderItemHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<RemoveOrderItemResponse> Handle(RemoveOrderItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemQuery()
            {
                Id = request.OrderItemId
            };
            var getOrderItem = await this.queryExecutor.Execute(query);
            if (getOrderItem == null)
            {
                return new RemoveOrderItemResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrderItem = mapper.Map<OrderItem>(request);
            var command = new RemoveOrderItemCommand()
            {
                Parameter = mappedOrderItem
            };
            var removedOrderItem = await this.commandExecutor.Execute(command);
            var response = new RemoveOrderItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderItemDTO>(removedOrderItem)
            };

            return response;
        }
    }
}
