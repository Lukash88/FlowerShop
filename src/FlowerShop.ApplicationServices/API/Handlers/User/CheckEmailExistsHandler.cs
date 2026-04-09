using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class CheckEmailExistsHandler(UserManager<AppUser> userManager, ILogger<CheckEmailExistsHandler> logger)
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
                Data = emailExists
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error checking if email exists: {Email}", request.EmailToCheck);
            
            return new CheckEmailExistsResponse
            {
                Error = new ErrorModel($"{ErrorType.InternalServerError} - Error checking email. {ex.Message}")
            };
        }
    }
}