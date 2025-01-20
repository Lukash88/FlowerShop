using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class UpdateUserHandler(IMapper mapper, UserManager<AppUser> userManager)
    : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var getUser = await userManager.Users
            .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        if (getUser is null)
        {
            return new UpdateUserResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        getUser.DisplayName = request.DisplayName;
        getUser.UserName = request.NewEmail;
        getUser.DateOfBirth = request.DateOfBirth;
        getUser.Gender = request.Gender;
        getUser.Email = request.NewEmail;
        getUser.PasswordHash = userManager.PasswordHasher.HashPassword(default, request.NewPassword);
            
        var updatedUser = await userManager.UpdateAsync(getUser);
        if (!updatedUser.Succeeded)
        {
            return new UpdateUserResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating the user")
            };
        }

        var mappedUser = mapper.Map<AppUser, AppUserDto>(getUser);
        var response = new UpdateUserResponse
        {
            Data = mappedUser
        };

        return response; 
    }
}