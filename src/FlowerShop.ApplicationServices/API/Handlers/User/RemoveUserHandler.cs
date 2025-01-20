using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class RemoveUserHandler(UserManager<AppUser> userManager)
    : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
{
    public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, 
        CancellationToken cancellationToken)
    {
        var getUser = await userManager.Users
            .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        if (getUser is null)
        {
            return new RemoveUserResponse
            {
                Error = new ErrorModel(ErrorType.NotFound + " - User not found")
            };
        }

        var removedUser =   await userManager.DeleteAsync(getUser);
        if (!removedUser.Succeeded)
        {
            return new RemoveUserResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem removing the user")
            };
        }

        var response = new RemoveUserResponse
        {
            Data = null
        };

        return response;
    }
}