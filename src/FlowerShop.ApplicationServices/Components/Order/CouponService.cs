using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class CouponService : ICouponService
{
    public CouponService(IConfiguration config)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];
    }

    public async Task<AppCoupon?> GetCoupon(string code)
    {
        var promotionService = new PromotionCodeService();
        var options = new PromotionCodeListOptions
        {
            Code = code
        };

        var promotionCodes = await promotionService.ListAsync(options);
        var promotionCode = promotionCodes.FirstOrDefault();

        if (promotionCode is null || string.IsNullOrEmpty(promotionCode.Promotion?.CouponId)) return null;

        var couponService = new Stripe.CouponService();
        var coupon = await couponService.GetAsync(promotionCode.Promotion.CouponId);
        if (coupon is not null)
        {
            return new AppCoupon
            {
                Name = coupon.Name,
                AmountOff = coupon.AmountOff,
                PercentOff = coupon.PercentOff,
                CouponId = coupon.Id,
                PromotionCode = promotionCode.Code
            };
        }

        return null;
    }
}