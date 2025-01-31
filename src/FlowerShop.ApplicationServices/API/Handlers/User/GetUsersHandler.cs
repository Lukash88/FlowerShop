using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class GetUsersHandler(IMapper mapper, ISieveProcessor sieveProcessor, ILogger<GetUsersHandler> logger,
    UserManager<AppUser> userManager) : PagedRequestHandler<GetUsersRequest, GetUsersResponse>
{
    public override async Task<GetUsersResponse> Handle(GetUsersRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a list of Users");

        var users = userManager.Users.Include(x => x.Address)
            .AsQueryable().AsNoTracking();          
        if (!users.Any())
        {
            return new GetUsersResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var results = await users.ToPagedAsync<AppUser, AppUserDto>(sieveProcessor, 
            mapper, request.SieveModel, cancellationToken: cancellationToken);
        var response = new GetUsersResponse
        {
            Data = results
        };

        return response;
    }
}