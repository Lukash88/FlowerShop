using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Coupon;

public sealed class GetCouponByCodeRequest : IRequest<GetCouponByCodeResponse>
{
    public required string Code { get; init; }
}