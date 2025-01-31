using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class CheckEmailExistsHandler(UserManager<AppUser> userManager)
    : IRequestHandler<CheckEmailExistsRequest, CheckEmailExistsResponse>
{
    public async Task<CheckEmailExistsResponse> Handle(CheckEmailExistsRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var emailExists = await userManager.FindByEmailAsync(request.EmailToCheck) != null;

            return new CheckEmailExistsResponse
            {
                Data = false
            };
        }
        catch (Exception ex)
        {
            // TODO: Log the exception
            return new CheckEmailExistsResponse
            {
                Error = new ErrorModel($"{ErrorType.ValidationError} - Email is already taken. {ex.Message}")
            };
        }
    }
}