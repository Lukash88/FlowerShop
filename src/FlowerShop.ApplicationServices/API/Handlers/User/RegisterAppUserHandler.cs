﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public RegisterApUserHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, 
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<RegisterAppUserResponse> Handle(RegisterAppUserRequest request, CancellationToken cancellationToken)
        {
            var userToAdd = _mapper.Map<AppUser>(request);
            var addUserResult = await _userManager.CreateAsync(userToAdd, request.Password);

            if (!addUserResult.Succeeded)
            {
                return new RegisterAppUserResponse()
                {
                    Error = new ErrorModel("Email is already taken")
                };
            }

            var addedUser = _mapper.Map<AppUserDto>(userToAdd);
            addedUser.Token = _tokenService.CreateToken(userToAdd);

            var response = new RegisterAppUserResponse()
            {
                Data = addedUser
            };

            return response;
        }
    }
}