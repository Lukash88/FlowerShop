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
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly IFlowersConnector flowersConnector;
        private readonly ILogger<GetFlowersHandler> logger;

        public GetFlowersHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor, 
            IFlowersConnector flowersConnector, ILogger<GetFlowersHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.flowersConnector = flowersConnector;
            this.logger = logger;
        }

        public override async Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
        {
            var cutFlowers = await this.flowersConnector.GetFlowersByType("Cut flowers: ");
            foreach (var flower in cutFlowers)
            {
                logger.LogInformation(flower);
            };

            var query = new  GetFlowersQuery() 
            {
                SieveModel = request.SieveModel
            };

            var flowers = await this.queryExecutor.ExecuteWithSieve(query);
            if (flowers is null)
            {
                return new GetFlowersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await flowers.ToPagedAsync<DataAccess.Core.Entities.Flower, FlowerDto>(sieveProcessor, 
                mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetFlowersResponse()
            {
                Data = results
            };

            return response;
        }
    }
}