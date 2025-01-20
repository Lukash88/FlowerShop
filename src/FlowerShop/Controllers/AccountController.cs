using FlowerShop.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System.Security.Claims;

namespace FlowerShop.Controllers;

[Authorize]
public class AccountController : ApiControllerBase
{
    public AccountController(IMediator mediator, ILogger<AccountController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Users");
    }

    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        var request = new GetCurrentUserRequest
        {
            CurrentUserEmail = email!
        };

        return await HandleRequest<GetCurrentUserRequest, GetCurrentUserResponse>(request);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetUsers([FromQuery] SieveModel sieveModel)
    {
        var request = new GetUsersRequest()
        {
            SieveModel = sieveModel
        };

        return await HandleRequest<GetUsersRequest, GetUsersResponse>(request);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAppUserRequest request) =>
        await HandleRequest<LoginAppUserRequest, LoginAppUserResponse>(request);

    [AllowAnonymous]
    [HttpGet("emailExists")]
    public async Task<IActionResult> CheckEmailExistsAsync([FromQuery] CheckEmailExistsRequest request)
    {
        return await HandleRequest<CheckEmailExistsRequest, CheckEmailExistsResponse>(request);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAppUser([FromBody] RegisterAppUserRequest request)
    {
        await CheckEmailExistsAsync(new CheckEmailExistsRequest { EmailToCheck = request.Email });

        return await HandleRequest<RegisterAppUserRequest, RegisterAppUserResponse>(request);
    }

    [HttpGet("address")]
    public async Task<IActionResult> GetUserAddress()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetUserAddressRequest()
        {
            Email = email!
        };

        return await HandleRequest<GetUserAddressRequest, GetUserAddressResponse>(request);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.Email = email!;

        await CheckEmailExistsAsync(new CheckEmailExistsRequest { EmailToCheck = request.NewEmail! });

        return await HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
    }

    [HttpPut("address")]
    public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateUserAddressRequest request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.Email = email!;

        return await HandleRequest<UpdateUserAddressRequest, UpdateUserAddressResponse>(request);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveUserByEmail(string userEmail)
    {
        var request = new RemoveUserRequest()
        {
            Email = userEmail
        };

        return await HandleRequest<RemoveUserRequest, RemoveUserResponse>(request);
    }
}