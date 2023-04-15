using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class RegisterApUserHandler : IRequestHandler<RegisterAppUserRequest, RegisterAppUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public RegisterApUserHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, 
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task<RegisterAppUserResponse> Handle(RegisterAppUserRequest request, CancellationToken cancellationToken)
        {
            var userToAdd = this.mapper.Map<AppUser>(request);
            var addUserResult = await this.userManager.CreateAsync(userToAdd, request.Password);

            if (!addUserResult.Succeeded)
            {
                return new RegisterAppUserResponse()
                {
                    Error = new ErrorModel("Email is already taken")
                };
            }

            var addedUser = this.mapper.Map<AppUserDto>(userToAdd);
            addedUser.Token = this.tokenService.CreateToken(userToAdd);

            var response = new RegisterAppUserResponse()
            {
                Data = addedUser
            };

            return response;
        }
    }
}