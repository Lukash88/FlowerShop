using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class ReservationDto
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public required DateTime DateOfEvent { get; init; }
    public DateTime ReservedOn { get; init; }
    public required ReservationState ReservationStatus { get; init; }
    public required EventType EventType { get; init; }
    public required string EventDescription { get; init; }
    public required string EventStreet { get; init; }
    public required string EventCity { get; init; }
    public required string EventPostalCode { get; init; }
    public decimal? ServicePrice { get; init; }
}