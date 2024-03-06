using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public RemoveUserHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            var getUser = await this.userManager.Users.SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (getUser is null)
            {
                return new RemoveUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound + " - User not found")
                };
            }

            var removedUser =   await this.userManager.DeleteAsync(getUser);
            if (!removedUser.Succeeded)
            {
                return new RemoveUserResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem removing the user")
                };
            }

            var response = new RemoveUserResponse()
            {
                Data = null
            };

            return response;
        }
    }
}