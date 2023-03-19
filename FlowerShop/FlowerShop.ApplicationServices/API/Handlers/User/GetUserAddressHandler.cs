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
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class GetUserAddressHandler : IRequestHandler<GetUserAddressRequest, GetUserAddressResponse>
    {
        private readonly IMapper mapper;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly ITokenService tokenService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public GetUserAddressHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<GetUserAddressResponse> Handle(GetUserAddressRequest request, CancellationToken cancellationToken)
        {
            var getUser = await this.userManager.Users.Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (getUser == null)
            {
                return new GetUserAddressResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var addressDto = this.mapper.Map<Address, AddressDto>(getUser.Address);
            var response = new GetUserAddressResponse()
            {
                Data = addressDto
            };

            return response;
        }
    }
}