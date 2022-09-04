namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain.User;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sieve.Models;
    using System.Threading.Tasks;

    [Authorize]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator, logger)
        {
            logger.LogInformation("We are in Users");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] SieveModel sieveModel)
        {
            GetUsersRequest request = new GetUsersRequest { SieveModel = sieveModel };

            return await this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpGet]
        [Route("{me}")]
        public async Task<IActionResult> GetCurrentUser([FromRoute] string me, string myEmail)
        {
            var request = new GetCurrentUserRequest()
            {
                CurrentUserName = me,
                CurrentUserEmail = myEmail
            };

            return await this.HandleRequest<GetCurrentUserRequest, GetCurrentUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("id/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };

            return await this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {

            return await this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
        
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveUserById([FromRoute] int userId)
        {
            var request = new RemoveUserRequest()
            {
                UserId = userId
            };
            
            return await this.HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
        }
        
        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] int userId, [FromBody] UpdateUserRequest request)
        {
            request.UserId = userId;
            
            return await this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }
    }
}