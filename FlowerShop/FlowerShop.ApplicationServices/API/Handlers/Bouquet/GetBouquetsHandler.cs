namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.ApplicationServices.API.Handlers;
    using FlowerShop.ApplicationServices.API.Handlers.Flower;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
    using Microsoft.Extensions.Logging;
    using Sieve.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBouquetsHandler : PagedRequestHandler<GetBouquetsRequest, GetBouquetsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetBouquetsHandler> logger;

        public GetBouquetsHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetBouquetsHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }        

        public async override Task<GetBouquetsResponse> Handle(GetBouquetsRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Bouquets");

            var query = new GetBouquetsQuery()
            {
                SieveModel = request.SieveModel
            };

            var bouquets = await this.queryExecutor.ExecuteWithSieve(query);
            if (bouquets is null)
            {
                return new GetBouquetsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await bouquets.ToPagedAsync<DataAccess.Core.Entities.Bouquet, BouquetDTO>(sieveProcessor, mapper, query.SieveModel);
            var response = new GetBouquetsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}