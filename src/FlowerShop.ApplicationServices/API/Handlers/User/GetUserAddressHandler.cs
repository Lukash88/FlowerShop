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

public class GetUserAddressHandler(IMapper mapper, UserManager<AppUser> userManager)
    : IRequestHandler<GetUserAddressRequest, GetUserAddressResponse>
{
    public async Task<GetUserAddressResponse> Handle(GetUserAddressRequest request,
        CancellationToken cancellationToken)
    {
        var getUser = await userManager.Users.Include(x => x.Address)
            .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        if (getUser is null)
        {
            return new GetUserAddressResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var addressDto = mapper.Map<Address, AddressDto>(getUser.Address);
        var response = new GetUserAddressResponse
        {
            Data = addressDto
        };

        return response;
    }
}