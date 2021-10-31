namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsRequest, GetOrderItemsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderItemsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderItemsResponse> Handle(GetOrderItemsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderItemsQuery()
            {
                Name = request.Name
            };
            var orderItems = await this.queryExecutor.Execute(query);
            var mappedOrderItems = this.mapper.Map<List<Domain.Models.OrderItemDTO>>(orderItems);
            var response = new GetOrderItemsResponse()
            {
                Data = mappedOrderItems
            };

            return response;
        }
    }
}
