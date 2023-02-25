namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using Microsoft.Extensions.Logging;
    using Sieve.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetOrderDetailsHandler : PagedRequestHandler<GetOrderDetailsRequest, GetOrderDetailsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetOrderDetailsHandler> logger;

        public GetOrderDetailsHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetOrderDetailsHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }

        public override async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Order Details");

            var query = new GetOrderDetailsQuery()
            {
                SieveModel = request.SieveModel
            };

            var orderDetails = await this.queryExecutor.ExecuteWithSieve(query);
            if (orderDetails == null)
            {
                return new GetOrderDetailsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await orderDetails.ToPagedAsync<DataAccess.Core.Entities.OrderDetail, OrderDetailDTO>(sieveProcessor, mapper, query.SieveModel);
            var response = new GetOrderDetailsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}