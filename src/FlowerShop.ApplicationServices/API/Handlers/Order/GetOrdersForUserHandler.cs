using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using Microsoft.Extensions.Logging;
using Sieve.Services;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class GetOrdersForUserHandler : PagedRequestHandler<GetOrdersForUserRequest, GetOrdersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetOrdersHandler> logger;

        public GetOrdersForUserHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetOrdersHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }

        public override async Task<GetOrdersResponse> Handle(GetOrdersForUserRequest request, 
            CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of User Orders");

            var query = new GetOrdersForUserQuery()
            {
                Email = request.Email,
                SieveModel = request.SieveModel
            };

            var orders = await this.queryExecutor.ExecuteWithSieve(query);
            if (orders is null)
            {
                return new GetOrdersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await orders.ToPagedAsync<DataAccess.Core.Entities.OrderAggregate.Order,
                OrderToReturnDto>(sieveProcessor, mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetOrdersResponse()
            {
                Data = results
            };

            return response;
        }
    }
}