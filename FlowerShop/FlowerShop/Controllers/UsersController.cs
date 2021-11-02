namespace FlowerShop.Controllers
{
using FlowerShop.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveUserById([FromRoute] int userId)
        {
            var request = new RemoveUserRequest()
            {
                UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] int userId, [FromBody] UpdateUserRequest request)
        {
            request.UserId = userId;
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
