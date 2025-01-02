using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public  class CheckEmailExistsHandler : IRequestHandler<CheckEmailExistsRequest, CheckEmailExistsResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CheckEmailExistsHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<CheckEmailExistsResponse> Handle(CheckEmailExistsRequest request, CancellationToken cancellationToken)
        {
            var  emailExists =  await _userManager.FindByEmailAsync(request.EmailToCheck) != null;

            return emailExists 
                ? new CheckEmailExistsResponse()
                {
                    Error = new ErrorModel("Email is already taken")
                } 
                : new CheckEmailExistsResponse()
                {
                    Data = false
                };
        }
    }
}