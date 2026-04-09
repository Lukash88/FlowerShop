using FlowerShop.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System.Security.Claims;

namespace FlowerShop.API.Controllers;

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
            Email = email!
        };

        return await HandleRequest<GetCurrentUserRequest, GetCurrentUserResponse>(request);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAppUserRequest request) =>
        await HandleRequest<LoginAppUserRequest, LoginAppUserResponse>(request);

    [AllowAnonymous]
    [HttpGet("email-exists")]
    public async Task<IActionResult> CheckEmailExistsAsync([FromQuery] CheckEmailExistsRequest request) =>
        await HandleRequest<CheckEmailExistsRequest, CheckEmailExistsResponse>(request);
    

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

    [AllowAnonymous]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var request = new GetUserInfoRequest
        {
            Email = email!
        };

        return await HandleRequest<GetUserInfoRequest, GetUserInfoResponse>(request);
    }
}