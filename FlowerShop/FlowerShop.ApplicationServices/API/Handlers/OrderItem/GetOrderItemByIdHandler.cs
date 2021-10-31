namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrderItemByIdHandler : IRequestHandler<GetOrderItemByIdRequest, GetOrderItemByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderItemByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderItemByIdResponse> Handle(GetOrderItemByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemQuery()
            {
                Id = request.OrderItemId
            };
            var orderItem = await this.queryExecutor.Execute(query);
            var mappedOrderItem = this.mapper.Map<Domain.Models.OrderItemDTO>(orderItem);
            var response = new GetOrderItemByIdResponse()
            {
                Data = mappedOrderItem
            };

            return response;
        }
    }
}
