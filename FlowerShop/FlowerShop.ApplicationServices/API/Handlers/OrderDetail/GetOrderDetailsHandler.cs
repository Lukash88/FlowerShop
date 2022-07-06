namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsRequest, GetOrderDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderDetailsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsQuery()
            {
                SieveModel = request.SieveModel
            };
            var orderDetails = await this.queryExecutor.Execute(query);
            if (orderDetails == null)
            {
                return new GetOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrderDetails = this.mapper.Map<List<Domain.Models.OrderDetailDTO>>(orderDetails);
            var response = new GetOrderDetailsResponse()
            {
                Data = mappedOrderDetails
            };

            return response;
        }
    }
}