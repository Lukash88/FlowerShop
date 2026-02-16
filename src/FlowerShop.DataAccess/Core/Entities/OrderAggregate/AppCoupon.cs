namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public sealed class AppCoupon
{
    public required string Name { get; init; }
    public decimal? AmountOff { get; init; }
    public decimal? PercentOff { get; init; }
    public required string PromotionCode { get; init; }
    public required string CouponId { get; init; }
}