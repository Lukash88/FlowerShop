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
    public class UpdateUserAddressHandler : IRequestHandler<UpdateUserAddressRequest, UpdateUserAddressResponse>
    {
        private readonly IMapper mapper;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly ITokenService tokenService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UpdateUserAddressHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<UpdateUserAddressResponse> Handle(UpdateUserAddressRequest request, CancellationToken cancellationToken)
        {
            var getUser = await this.userManager.Users.Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (getUser == null)
            {
                return new UpdateUserAddressResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            getUser.Address = this.mapper.Map<UpdateUserAddressRequest, Address>(request);
            var updatedUser = await this.userManager.UpdateAsync(getUser);

            if (!updatedUser.Succeeded)
            {
                return new UpdateUserAddressResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + "\nProblem updating the user")
                };
            }
            var addressDto = this.mapper.Map<Address, AddressDto>(getUser.Address);

            var response = new UpdateUserAddressResponse()
            {
                Data = addressDto
            };

            return response;
        }
    }
}