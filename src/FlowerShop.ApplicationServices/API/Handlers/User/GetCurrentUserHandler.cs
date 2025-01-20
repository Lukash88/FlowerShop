using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class GetCurrentUserHandler(IMapper mapper, ITokenService tokenService, UserManager<AppUser> userManager)
    : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
{
    public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var getUser = await userManager.FindByEmailAsync(request.CurrentUserEmail);
        if (getUser is null)
        {
            return new GetCurrentUserResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var user = mapper.Map<UserDto>(getUser);
        user.Token = tokenService.CreateToken(getUser);

        var response = new GetCurrentUserResponse
        {
            Data = user
        };

        return response;
    }
}