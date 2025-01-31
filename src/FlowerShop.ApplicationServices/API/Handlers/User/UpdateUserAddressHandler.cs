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

public class UpdateUserAddressHandler(IMapper mapper, UserManager<AppUser> userManager)
    : IRequestHandler<UpdateUserAddressRequest, UpdateUserAddressResponse>
{
    public async Task<UpdateUserAddressResponse> Handle(UpdateUserAddressRequest request,
        CancellationToken cancellationToken)
    {
        var getUser = await userManager.Users.Include(x => x.Address)
            .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
        if (getUser is null)
        {
            return new UpdateUserAddressResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        getUser.Address = mapper.Map<UpdateUserAddressRequest, Address>(request);
        var updatedUser = await userManager.UpdateAsync(getUser);

        if (!updatedUser.Succeeded)
        {
            return new UpdateUserAddressResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating the user")
            };
        }
        var addressDto = mapper.Map<Address, AddressDto>(getUser.Address);

        var response = new UpdateUserAddressResponse
        {
            Data = addressDto
        };

        return response;
    }
}