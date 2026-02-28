using FlowerShop.ApplicationServices.API.Domain.Coupon;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.API.Controllers;

public class CouponsController : ApiControllerBase
{
    public CouponsController(IMediator mediator, ILogger<CartController> logger) : base(mediator, logger)
    {
        logger.LogInformation("We are in Coupons Controller");
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetCouponByCode([FromRoute] string code)
    {
        var request = new GetCouponByCodeRequest
        {
            Code = code
        };

        return await HandleRequest<GetCouponByCodeRequest, GetCouponByCodeResponse>(request);
    }
}