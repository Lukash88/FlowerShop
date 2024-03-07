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
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ILogger<GetOrdersHandler> _logger;

        public GetOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor, 
            ISieveProcessor sieveProcessor, ILogger<GetOrdersHandler> logger)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
        }

        public override async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting a list of Orders");

            var query = new GetOrdersQuery()
            {
                SieveModel = request.SieveModel
            };

            var orders = await _queryExecutor.ExecuteWithSieve(query);
            if (orders is null)
            {
                return new GetOrdersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await orders.ToPagedAsync<DataAccess.Core.Entities.OrderAggregate.Order, OrderToReturnDto>(_sieveProcessor, 
                _mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetOrdersResponse()
            {
                Data = results
            };

            return response;
        }
    }
}