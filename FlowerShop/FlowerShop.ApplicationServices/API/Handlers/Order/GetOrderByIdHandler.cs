namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Order;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery()
            {
                Id = request.OrderId
            };
            var orderItem = await this.queryExecutor.Execute(query);
            if (orderItem == null)
            {
                return new GetOrderByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrderItem = this.mapper.Map<Domain.Models.OrderDTO>(orderItem);
            var response = new GetOrderByIdResponse()
            {
                Data = mappedOrderItem
            };

            return response;
        }
    }
}
