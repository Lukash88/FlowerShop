using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
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
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public UpdateUserHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var getUser = await this.userManager.Users.SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (getUser == null)
            {
                return new UpdateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            getUser.DisplayName = request.DisplayName;
            getUser.UserName = request.NewEmail;
            getUser.DateOfBirth = request.DateOfBirth;
            getUser.Gender = request.Gender;
            getUser.Email = request.NewEmail;
            getUser.PasswordHash = this.userManager.PasswordHasher.HashPassword(default, request.NewPassword);
            
            var updatedUser = await this.userManager.UpdateAsync(getUser);
            if (!updatedUser.Succeeded)
            {
                return new UpdateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem updating the user")
                };
            }

            var mappedUser = this.mapper.Map<AppUser, AppUserDto>(getUser);
            var response = new UpdateUserResponse()
            {
                Data = mappedUser
            };

            return response; 
        }
    }
}