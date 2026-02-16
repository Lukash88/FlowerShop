using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Cart;

public class UpdateCartRequest : IRequest<UpdateCartResponse>
{
    public string? Id { get; set; }
    public List<CartItemDto> Items { get; set; } = [];
    public int? DeliveryMethodId { get; init; }
    public string? ClientSecret { get; init; }
    public string? PaymentIntentId { get; init; }
    public AppCoupon? Coupon { get; init; }
}