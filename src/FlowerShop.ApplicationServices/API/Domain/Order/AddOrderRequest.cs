using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using MediatR;
using ReservationEntity = FlowerShop.DataAccess.Core.Entities.Reservation;

namespace FlowerShop.ApplicationServices.API.Domain.Order;

public class AddOrderRequest : IRequest<AddOrderResponse>
{
    public string? BasketId { get; init; }
    public string? BuyerEmail { get; set; }
    public ShippingAddress? ShippingAddress { get; init; }
    public int DeliveryMethodId { get; init; }
    public decimal Subtotal { get; set; }
    public string Status { get; init; } = "Pending";
    public string? Invoice { get; init; }
    public string? PaymentIntentId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = [];
    public List<ReservationEntity> Reservations { get; init; } = [];
}