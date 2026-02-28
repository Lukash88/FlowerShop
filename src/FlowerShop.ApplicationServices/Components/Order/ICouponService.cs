using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Components.Order;

public interface ICouponService
{
    Task<AppCoupon?> GetCoupon(string promoCode);
}