using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class RegisterAppUserHandler(IMapper mapper, UserManager<AppUser> userManager, ITokenService tokenService)
    : IRequestHandler<RegisterAppUserRequest, RegisterAppUserResponse>
{
    public async Task<RegisterAppUserResponse> Handle(RegisterAppUserRequest request,
        CancellationToken cancellationToken)
    {
        var userToAdd = mapper.Map<AppUser>(request);
        var addUserResult = await userManager.CreateAsync(userToAdd, request.Password);

        if (!addUserResult.Succeeded)
        {
            return new RegisterAppUserResponse
            {
                Error = new ErrorModel("Email is already taken")
            };
        }

        var addedUser = mapper.Map<AppUserDto>(userToAdd);
        addedUser.Token = tokenService.CreateToken(userToAdd);

        var response = new RegisterAppUserResponse
        {
            Data = addedUser
        };

        return response;
    }
}