namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrderDetailByIdHandler : IRequestHandler<GetOrderDetailByIdRequest, GetOrderDetailByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderDetailByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderDetailByIdResponse> Handle(GetOrderDetailByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailQuery()
            {
                Id = request.OrderDetailId
            };
            var orderDetail = await this.queryExecutor.Execute(query);
            if (orderDetail == null)
            {
                return new GetOrderDetailByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOrderDetail = this.mapper.Map<Domain.Models.OrderDetailDTO>(orderDetail);
            var response = new GetOrderDetailByIdResponse()
            {
                Data = mappedOrderDetail
            };

            return response;
        }
    }
}
