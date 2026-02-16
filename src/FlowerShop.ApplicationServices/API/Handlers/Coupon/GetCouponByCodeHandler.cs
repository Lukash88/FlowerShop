using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Coupon;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Order;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Coupon;

public sealed class GetCouponByCodeHandler(ICouponService couponService)
    : IRequestHandler<GetCouponByCodeRequest, GetCouponByCodeResponse>
{
    public async Task<GetCouponByCodeResponse> Handle(GetCouponByCodeRequest request,
        CancellationToken cancellationToken)
    {
        var coupon = await couponService.GetCoupon(request.Code);
        if (coupon is null)
        {
            return new GetCouponByCodeResponse
            {
                Error = new ErrorModel(ErrorType.NotFound + " - Invalid voucher code")
            };
        }

        var response = new GetCouponByCodeResponse
        {
            Data = coupon
        };

        return response;
    }
}
