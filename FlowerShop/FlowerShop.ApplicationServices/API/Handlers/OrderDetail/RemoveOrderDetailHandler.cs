namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveOrderDetailHandler : IRequestHandler<RemoveOrderDetailRequest, RemoveOrderDetailResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveOrderDetailHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<RemoveOrderDetailResponse> Handle(RemoveOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailQuery()
            {
                Id = request.OrderDetailId
            };
            var getOrderDetail = await this.queryExecutor.Execute(query);
            if (getOrderDetail == null)
            {
                return new RemoveOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrderDetail = mapper.Map<OrderDetail>(request);
            var command = new RemoveOrderDetailCommand()
            {
                Parameter = mappedOrderDetail
            };
            var removedOrderDetail = await this.commandExecutor.Execute(command);
            var response = new RemoveOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetailDTO>(removedOrderDetail)
            };

            return response;
        }
    }
}
