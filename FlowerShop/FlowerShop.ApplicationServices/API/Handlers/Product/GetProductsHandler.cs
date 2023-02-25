namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.ApplicationServices.API.Handlers;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Product;
    using Microsoft.Extensions.Logging;
    using Sieve.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetProductsHandler : PagedRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetProductsHandler> logger;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, 
            ISieveProcessor sieveProcessor, ILogger<GetProductsHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }

        public override async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Products");

            var query = new GetProductsQuery()
            {
                SieveModel = request.SieveModel
            };

            var products = await this.queryExecutor.ExecuteWithSieve(query);
            if (products is null)
            {
                return new GetProductsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }          

            var results = await products.ToPagedAsync<DataAccess.Core.Entities.Product, ProductDTO>(sieveProcessor, mapper, query.SieveModel);
            var response = new GetProductsResponse() 
            { 
                Data = results 
            };

            return response;
        }
    }
}