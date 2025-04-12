using FlowerShop.ApplicationServices.API.Domain.Models;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Cart;

public class UpdateCartRequest : IRequest<UpdateCartResponse>
{
    public string? CartId { get; set; }
    public List<CartItemDto> Items { get; set; } = [];
    public int? DeliveryMethodId { get; init; }
    public string? ClientSecret { get; init; }
    public string? PaymentIntentId { get; init; }
}