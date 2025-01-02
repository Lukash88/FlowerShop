using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class UpdateUserAddressHandler : IRequestHandler<UpdateUserAddressRequest, UpdateUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UpdateUserAddressHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UpdateUserAddressResponse> Handle(UpdateUserAddressRequest request, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.Users.Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (getUser is null)
            {
                return new UpdateUserAddressResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            getUser.Address = _mapper.Map<UpdateUserAddressRequest, Address>(request);
            var updatedUser = await _userManager.UpdateAsync(getUser);

            if (!updatedUser.Succeeded)
            {
                return new UpdateUserAddressResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating the user")
                };
            }
            var addressDto = _mapper.Map<Address, AddressDto>(getUser.Address);

            var response = new UpdateUserAddressResponse()
            {
                Data = addressDto
            };

            return response;
        }
    }
}