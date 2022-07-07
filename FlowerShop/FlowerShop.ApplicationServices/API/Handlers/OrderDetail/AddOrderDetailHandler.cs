namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using Sieve.Models;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOrderDetailHandler : IRequestHandler<AddOrderDetailRequest, AddOrderDetailResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderDetailHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderDetailResponse> Handle(AddOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetailsQuery = new GetOrderDetailsQuery() { SieveModel = new SieveModel() }; //??
            var getOrderDetails = await this.queryExecutor.ExecuteWithSieve(orderDetailsQuery);
            var ordersQuery = new GetOrdersQuery() { SieveModel = new SieveModel() }; //??
            var getOrders = await this.queryExecutor.ExecuteWithSieve(ordersQuery);
            if ((getOrders.Select(x => x.Id).Contains(request.OrderId) && 
                getOrderDetails.Select(x => x.OrderId).Contains(request.OrderId)) ||
                !getOrders.Select(x => x.Id).Contains(request.OrderId))
            {
                return new AddOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var orderDetail = this.mapper.Map<OrderDetail>(request);
            var command = new AddOrderDetailCommand() 
            { 
                Parameter = orderDetail 
            };      
            var addedOrderDetail = await this.commandExecutor.Execute(command);
            var response = new AddOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetailDTO>(addedOrderDetail)
            };

            return response;
        }
    }
}