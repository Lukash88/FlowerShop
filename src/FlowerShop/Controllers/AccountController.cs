using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class AccountController : ApiControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            IMediator mediator, ILogger<AccountController> logger) : base(mediator, logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            logger.LogInformation("We are in Users");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var request = new GetCurrentUserRequest()
            {
                CurrentUserEmail = email
            };

            return await this.HandleRequest<GetCurrentUserRequest, GetCurrentUserResponse>(request);
        }
        
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetUsers([FromQuery] SieveModel sieveModel)
        {
            var request = new GetUsersRequest()
            {
                SieveModel = sieveModel
            };

            return await this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserRequest request) =>
            await this.HandleRequest<LoginAppUserRequest, LoginAppUserResponse>(request);

        [AllowAnonymous]
        [HttpGet]
        [Route("emailExists")]
        public async Task<IActionResult> CheckEmailExistsAsync([FromQuery] CheckEmailExistsRequest request)
        {
            return await this.HandleRequest<CheckEmailExistsRequest, CheckEmailExistsResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAppUser([FromBody] RegisterAppUserRequest request)
        {
            await CheckEmailExistsAsync(new CheckEmailExistsRequest(request.Email));

            return await this.HandleRequest<RegisterAppUserRequest, RegisterAppUserResponse>(request);
        }
        
        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var request = new GetUserAddressRequest()
            {
                Email = email
            };

            return await this.HandleRequest<GetUserAddressRequest, GetUserAddressResponse>(request);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            request.Email = email;

            await CheckEmailExistsAsync(new CheckEmailExistsRequest(request.NewEmail));

            return await this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }

        [HttpPut]
        [Route("address")]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateUserAddressRequest request)
        {

            var email = User.FindFirstValue(ClaimTypes.Email);
            request.Email = email;

            return await this.HandleRequest<UpdateUserAddressRequest, UpdateUserAddressResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> RemoveUserByEmail(string userEmail)
        {
            var request = new RemoveUserRequest()
            {
                Email = userEmail
            };

            return await this.HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
        }
    }
}