using FlowerShop.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
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

        //[HttpGet]
        //[Route("{userId}")]
        //public async Task<IActionResult> GetUserById([FromRoute] GetUsersRequest request)
        //{
        //    var response = await this.mediator.Send(request);
        //    return this.Ok(response);
        //}
    }
}
