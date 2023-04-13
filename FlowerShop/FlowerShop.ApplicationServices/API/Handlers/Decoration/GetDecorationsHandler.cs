using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    public class GetDecorationsHandler : PagedRequestHandler<GetDecorationsRequest, GetDecorationsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetDecorationsHandler> logger;

        public GetDecorationsHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetDecorationsHandler> logger)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;   
        }

        public override async Task<GetDecorationsResponse> Handle(GetDecorationsRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Decorations");

            var query = new GetDecorationsQuery()
            {
                SieveModel = request.SieveModel
            };

            var decorations = await this.queryExecutor.ExecuteWithSieve(query);
            if (decorations == null)
            {
                return new GetDecorationsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await decorations.ToPagedAsync<DataAccess.Core.Entities.Decoration, DecorationDto>(sieveProcessor, 
                mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetDecorationsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}