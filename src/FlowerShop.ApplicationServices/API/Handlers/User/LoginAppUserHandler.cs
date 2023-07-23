using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class LoginAppUserHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly ITokenService tokenService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public LoginAppUserHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {
            var getUser = await this.userManager.FindByEmailAsync(request.Email);

            if (getUser == null)
            {
                return new LoginAppUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var signInResult = await this.signInManager.CheckPasswordSignInAsync(getUser, request.Password, false);

            if (!signInResult.Succeeded)
            {
                return new LoginAppUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var loggedUser = this.mapper.Map<UserDto>(getUser);
            loggedUser.Token = this.tokenService.CreateToken(getUser);

            var response = new LoginAppUserResponse()
            {
                Data = loggedUser
            };

            return response;
        }
    }
}