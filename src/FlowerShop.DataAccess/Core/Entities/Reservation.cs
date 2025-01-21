using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public class Reservation : IEntityBase
{
    public int Id { get; init; }
    public required DateTime DateOfEvent { get; init; }
    public DateTime ReservedOn { get; init; }
    public required ReservationState ReservationStatus { get; init; }
    public required EventType EventType { get; init; }
    public required string EventDescription { get; init; }
    public required string EventStreet { get; init; }
    public required string EventCity { get; init; }
    public required string EventPostalCode { get; init; }
    public decimal? ServicePrice { get; init; }

    public Order? Order { get; init; }
    public int OrderId { get; init; }
}