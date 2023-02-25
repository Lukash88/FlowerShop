namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Order;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveOrderHandler : IRequestHandler<RemoveOrderRequest, RemoveOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public RemoveOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<RemoveOrderResponse> Handle(RemoveOrderRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery()
            {
                Id = request.OrderId
            };
            var getOrder = await this.queryExecutor.Execute(query);
            if (getOrder == null)
            {
                return new RemoveOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrder = mapper.Map<DataAccess.Core.Entities.Order>(request);
            var command = new RemoveOrderCommand()
            {
                Parameter = mappedOrder
            };
            var removedOrder = await this.commandExecutor.Execute(command);
            var response = new RemoveOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDTO>(removedOrder)
            };

            return response;
        }
    }
}