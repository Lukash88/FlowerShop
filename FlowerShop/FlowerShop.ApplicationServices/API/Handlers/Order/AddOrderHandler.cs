namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Order;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.CQRS.Queries.User;
    using MediatR;
    using Sieve.Models;
    using System.Linq;
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
            var ordersQuery = new GetOrdersQuery(); 
            var getOrders = await this.queryExecutor.ExecuteWithSieve(ordersQuery);
            var usersQuery = new GetUsersQuery();
            var getUsers = await this.queryExecutor.ExecuteWithSieve(ordersQuery);

            if ((getUsers.Select(x => x.Id).Contains(request.UserId) &&
                getOrders.Select(x => x.UserId).Contains(request.UserId)) ||
                !getOrders.Select(x => x.Id).Contains(request.UserId))
            {
                return new AddOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var order = this.mapper.Map<DataAccess.Core.Entities.Order>(request);
            var command = new AddOrderCommand()
            {
                Parameter = order
            };
            var addedOrder = await this.commandExecutor.Execute(command);
            var response = new AddOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDTO>(addedOrder)
            };

            return response;
        }
    }
}