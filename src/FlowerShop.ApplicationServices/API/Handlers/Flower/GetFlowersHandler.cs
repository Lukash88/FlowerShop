using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Flowers;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Flower;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    public class GetFlowersHandler : PagedRequestHandler<GetFlowersRequest, GetFlowersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly IFlowersConnector _flowersConnector;
        private readonly ILogger<GetFlowersHandler> _logger;

        public GetFlowersHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor, 
            IFlowersConnector flowersConnector, ILogger<GetFlowersHandler> logger)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _flowersConnector = flowersConnector;
            _logger = logger;
        }

        public override async Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
        {
            var cutFlowers = await _flowersConnector.GetFlowersByType("Cut flowers: ");
            foreach (var flower in cutFlowers)
            {
                _logger.LogInformation(flower);
            };

            var query = new  GetFlowersQuery() 
            {
                SieveModel = request.SieveModel
            };

            var flowers = await _queryExecutor.ExecuteWithSieve(query);
            if (flowers is null)
            {
                return new GetFlowersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await flowers.ToPagedAsync<DataAccess.Core.Entities.Flower, FlowerDto>(_sieveProcessor, 
                _mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetFlowersResponse()
            {
                Data = results
            };

            return response;
        }
    }
}