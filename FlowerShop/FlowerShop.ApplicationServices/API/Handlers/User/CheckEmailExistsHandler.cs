using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public  class CheckEmailExistsHandler : IRequestHandler<CheckEmailExistsRequest, CheckEmailExistsResponse>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public CheckEmailExistsHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<CheckEmailExistsResponse> Handle(CheckEmailExistsRequest request, CancellationToken cancellationToken)
        {
            var  emailExists =  await this.userManager.FindByEmailAsync(request.EmailToCheck) != null;

            if (emailExists)
            {
                return new CheckEmailExistsResponse()
                {
                    Error = new ErrorModel("Email is already taken"),    
                    Result = true
                };
            }

            return new CheckEmailExistsResponse()
            {
                Result = false
            };
        }
    }
}