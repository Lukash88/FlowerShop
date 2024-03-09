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
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public GetCurrentUserHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.FindByEmailAsync(request.CurrentUserEmail);
            if (getUser is null)
            {
                return new GetCurrentUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var user = _mapper.Map<UserDto>(getUser);
            user.Token = _tokenService.CreateToken(getUser);

            var response = new GetCurrentUserResponse()
            {
                Data = user
            };

            return response;
        }
    }
}