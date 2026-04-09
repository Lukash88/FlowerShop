using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using FlowerShop.ApplicationServices.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FlowerShop.ApplicationServices.Components.Token;

namespace FlowerShop.ApplicationServices.API.Handlers.User;

public class GetUserInfoHandler(IMapper mapper, ITokenService tokenService, UserManager<AppUser> userManager)
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
                    Data = null
                };
            }

            var roles = await userManager.GetRolesAsync(user);

            var userInfoDto = mapper.Map<UserInfoDto>(user);
            userInfoDto.Token = tokenService.CreateToken(user, roles);
            userInfoDto.Roles = roles.ToArray();

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