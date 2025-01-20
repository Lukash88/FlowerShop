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

public class LoginAppUserHandler(IMapper mapper, ITokenService tokenService, UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager) : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
{
    public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, 
        CancellationToken cancellationToken)
    {
        var getUser = await userManager.FindByEmailAsync(request.Email);

        if (getUser is null)
        {
            return new LoginAppUserResponse
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        var signInResult = await signInManager.CheckPasswordSignInAsync(getUser, request.Password, false);

        if (!signInResult.Succeeded)
        {
            return new LoginAppUserResponse
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        var loggedUser = mapper.Map<UserDto>(getUser);
        loggedUser.Token = tokenService.CreateToken(getUser);

        var response = new LoginAppUserResponse
        {
            Data = loggedUser
        };

        return response;
    }
}