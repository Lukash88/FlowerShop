using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Token;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class LoginAppUserHandler : IRequestHandler<LoginAppUserRequest, LoginAppUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginAppUserHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginAppUserResponse> Handle(LoginAppUserRequest request, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.FindByEmailAsync(request.Email);

            if (getUser is null)
            {
                return new LoginAppUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(getUser, request.Password, false);

            if (!signInResult.Succeeded)
            {
                return new LoginAppUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var loggedUser = _mapper.Map<UserDto>(getUser);
            loggedUser.Token = _tokenService.CreateToken(getUser);

            var response = new LoginAppUserResponse()
            {
                Data = loggedUser
            };

            return response;
        }
    }
}