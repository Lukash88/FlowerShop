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
        private readonly IMapper mapper;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly ITokenService tokenService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public GetCurrentUserHandler(IMapper mapper, IPasswordHasher<AppUser> passwordHasher, ITokenService tokenService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var getUser = await this.userManager.FindByEmailAsync(request.CurrentUserEmail);
            if (getUser == null)
            {
                return new GetCurrentUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var user = this.mapper.Map<UserDto>(getUser);
            user.Token = this.tokenService.CreateToken(getUser);

            var response = new GetCurrentUserResponse()
            {
                Data = user
            };

            return response;
        }
    }
}