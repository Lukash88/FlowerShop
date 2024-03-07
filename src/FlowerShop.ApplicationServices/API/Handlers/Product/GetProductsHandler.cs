using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    public class GetProductsHandler : PagedRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ILogger<GetProductsHandler> _logger;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, 
            ISieveProcessor sieveProcessor, ILogger<GetProductsHandler> logger)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
        }

        public override async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting a list of Products");

            var query = new GetProductsQuery()
            {
                SieveModel = request.SieveModel
            };

            var products = await _queryExecutor.ExecuteWithSieve(query);
            if (products is null)
            {
                return new GetProductsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }          

            var results = await products.ToPagedAsync<DataAccess.Core.Entities.Product, ProductDto>(_sieveProcessor, 
                _mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetProductsResponse() 
            { 
                Data = results 
            };

            return response;
        }
    }
}