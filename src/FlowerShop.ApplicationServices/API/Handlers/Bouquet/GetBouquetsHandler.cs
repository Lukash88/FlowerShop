using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class GetBouquetsHandler : PagedRequestHandler<GetBouquetsRequest, GetBouquetsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ILogger<GetBouquetsHandler> _logger;

        public GetBouquetsHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetBouquetsHandler> logger)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
        }        

        public override async Task<GetBouquetsResponse> Handle(GetBouquetsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting a list of Bouquets");

            var query = new GetBouquetsQuery()
            {
                SieveModel = request.SieveModel
            };

            var bouquets = await _queryExecutor.ExecuteWithSieve(query);
            if (bouquets is null)
            {
                return new GetBouquetsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await bouquets.ToPagedAsync<DataAccess.Core.Entities.Bouquet, BouquetDto>(_sieveProcessor, 
                _mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetBouquetsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}