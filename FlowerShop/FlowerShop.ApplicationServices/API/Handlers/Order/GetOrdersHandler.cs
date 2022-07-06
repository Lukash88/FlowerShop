namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersQuery()
            {
                SieveModel = request.SieveModel
            };
            var orders = await this.queryExecutor.Execute(query);
            if (orders == null)
            {
                return new GetOrdersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrders = this.mapper.Map<List<Domain.Models.OrderDTO>>(orders);
            var response = new GetOrdersResponse()
            {
                Data = mappedOrders
            };

            return response;
        }
    }
}