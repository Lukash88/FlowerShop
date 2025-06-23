using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using FlowerShop.ApplicationServices.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class GetUserInfoHandler(IMapper mapper, UserManager<AppUser> userManager)
    : IRequestHandler<GetUserInfoRequest, GetUserInfoResponse>
{
    public async Task<GetUserInfoResponse> Handle(GetUserInfoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await userManager.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user is null)
            {
                return new GetUserInfoResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };

                //return new GetUserInfoResponse
                //{
                //   Data = null
                //};
            }

            var userInfoDto = mapper.Map<UserInfoDto>(user);

            return new GetUserInfoResponse
            {
                Data = userInfoDto
            };
        }
        catch (Exception ex)
        {
            // TODO: Log the exception
            return new GetUserInfoResponse
            {
                Error = new ErrorModel($"{ErrorType.Unauthorized} - Unexpected error: {ex.Message}")
            };
        }
    }
}