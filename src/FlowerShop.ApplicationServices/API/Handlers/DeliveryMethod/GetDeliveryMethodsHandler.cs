using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class GetDeliveryMethodsHandler : PagedRequestHandler<GetDeliveryMethodsRequest, GetDeliveryMethodsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ILogger<GetDeliveryMethodsHandler> _logger;

        public GetDeliveryMethodsHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetDeliveryMethodsHandler> logger)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
        }

        public override async Task<GetDeliveryMethodsResponse> Handle(GetDeliveryMethodsRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting a list of Delivery Methods");

            var query = new GetDeliveryMethodsQuery()
            {
                SieveModel = request.SieveModel
            };

            var deliveryMethods = await _queryExecutor.ExecuteWithSieve(query);
            if (deliveryMethods is null)
            {
                return new GetDeliveryMethodsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await deliveryMethods.ToPagedAsync<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod,
                DeliveryMethodDto>(_sieveProcessor, _mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetDeliveryMethodsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}