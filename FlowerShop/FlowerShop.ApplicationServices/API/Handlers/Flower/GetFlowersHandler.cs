namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.ApplicationServices.Components.Flowers;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Flower;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFlowersHandler : IRequestHandler<GetFlowersRequest, GetFlowersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly IFlowersConnector flowersConnector;
        private readonly ILogger<GetFlowersHandler> logger;

        public GetFlowersHandler(IMapper mapper, IQueryExecutor queryExecutor, IFlowersConnector flowersConnector, ILogger<GetFlowersHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.flowersConnector = flowersConnector;
            this.logger = logger;
        }

        public async Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
        {
            var f = await this.flowersConnector.GetFlowersByType("Cut flowers: ");
            foreach (var flower in f)
            {
                logger.LogInformation(flower);
            };
            var query = new GetFlowersQuery() 
            {
                SieveModel = request.SieveModel
            };
            var flowers = await this.queryExecutor.ExecuteWithSieve(query);
            if (flowers == null)
            {
                return new GetFlowersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedFlowers = this.mapper.Map<List<Domain.Models.FlowerDTO>>(flowers);
            var response = new GetFlowersResponse()
            {
                Data = mappedFlowers
            };

            return response;
        }
    }
}