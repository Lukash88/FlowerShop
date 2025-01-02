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
    public class GetUserAddressHandler : IRequestHandler<GetUserAddressRequest, GetUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public GetUserAddressHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<GetUserAddressResponse> Handle(GetUserAddressRequest request, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.Users.Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (getUser is null)
            {
                return new GetUserAddressResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var addressDto = _mapper.Map<Address, AddressDto>(getUser.Address);
            var response = new GetUserAddressResponse()
            {
                Data = addressDto
            };

            return response;
        }
    }
}