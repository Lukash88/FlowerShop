using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class GetOrdersHandler : PagedRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetOrdersHandler> logger;

        public GetOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor, 
            ISieveProcessor sieveProcessor, ILogger<GetOrdersHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }

        public override async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Orders");

            var query = new GetOrdersQuery()
            {
                SieveModel = request.SieveModel
            };

            var orders = await this.queryExecutor.ExecuteWithSieve(query);
            if (orders == null)
            {
                return new GetOrdersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await orders.ToPagedAsync<DataAccess.Core.Entities.Order, OrderDto>(sieveProcessor, 
                mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetOrdersResponse()
            {
                Data = results
            };

            return response;
        }
    }
}