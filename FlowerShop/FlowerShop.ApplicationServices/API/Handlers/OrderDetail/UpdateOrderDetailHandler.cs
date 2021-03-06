namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using DataAccess.Entities;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailRequest, UpdateOrderDetailResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateOrderDetailHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateOrderDetailResponse> Handle(UpdateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailQuery()
            {
                Id = request.OrderDetailId
            };
            var getOrderDetail = await this.queryExecutor.Execute(query);
            if (getOrderDetail == null)
            {
                return new UpdateOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var orderDetailsQuery = new GetOrderDetailsQuery();
            var getOrderDetails = await this.queryExecutor.Execute(orderDetailsQuery);
            var ordersQuery = new GetOrdersQuery();
            var getOrders = await this.queryExecutor.Execute(ordersQuery);

            if ((getOrders.Select(x => x.Id).Contains(request.OrderId) &&
                getOrderDetails.Select(x => x.OrderId).Contains(request.OrderId)) || 
                !getOrders.Select(x => x.Id).Contains(request.OrderId))
            {
                return new UpdateOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrderDetail = this.mapper.Map<OrderDetail>(request);
            var command = new UpdateOrderDetailCommand()
            {
                Parameter = mappedOrderDetail
            };
            var updatedOrderDetail = await this.commandExecutor.Execute(command);
            var response =  new UpdateOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetailDTO>(updatedOrderDetail)
            };

            return response;
        }
    }
}