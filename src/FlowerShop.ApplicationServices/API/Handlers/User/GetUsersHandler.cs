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
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ILogger<GetUsersHandler> _logger;
        private readonly UserManager<AppUser> _userManager;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ISieveProcessor sieveProcessor, ILogger<GetUsersHandler> logger, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
            _userManager = userManager;
        }

        public override async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting a list of Users");

            var users = _userManager.Users.Include(x => x.Address).AsQueryable().AsNoTracking();          
            if (!users.Any())
            {
                return new GetUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await users.ToPagedAsync<AppUser, AppUserDto>(_sieveProcessor, 
                _mapper, request.SieveModel, cancellationToken: cancellationToken);
            var response = new GetUsersResponse()
            {
                  Data = results
            };

            return response;
        }
    }
}