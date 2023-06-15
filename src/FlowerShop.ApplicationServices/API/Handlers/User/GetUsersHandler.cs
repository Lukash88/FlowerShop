using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using FlowerShop.DataAccess.CQRS;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class GetUsersHandler  : PagedRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetUsersHandler> logger;
        private readonly UserManager<AppUser> userManager;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetUsersHandler> logger, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
            this.userManager = userManager;
        }

        public override async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Users");

            var users = this.userManager.Users.Include(x => x.Address).AsQueryable().AsNoTracking();          
            if (!users.Any())
            {
                return new GetUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await users.ToPagedAsync<AppUser, AppUserDto>(sieveProcessor, 
                mapper, request.SieveModel, cancellationToken: cancellationToken);
            var response = new GetUsersResponse()
            {
                  Data = results
            };

            return response;
        }
    }
}