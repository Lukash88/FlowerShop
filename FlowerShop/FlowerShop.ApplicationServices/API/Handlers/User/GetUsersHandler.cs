namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.User;
    using Microsoft.Extensions.Logging;
    using Sieve.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUsersHandler : PagedRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetUsersHandler> logger;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetUsersHandler> logger)
        {   
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }

        public override async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Users");

            var query = new GetUsersQuery()
            {
                SieveModel = request.SieveModel
            };

            var users = await this.queryExecutor.ExecuteWithSieve(query);
            if (users == null)
            {
                return new GetUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await users.ToPagedAsync<DataAccess.Core.Entities.User, UserDTO>(sieveProcessor, mapper, query.SieveModel);
            var response = new GetUsersResponse()
            {
                Data = results
            };

            return response;
        }
    }
}