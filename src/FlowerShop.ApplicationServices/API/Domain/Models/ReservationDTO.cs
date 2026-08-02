using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class ReservationDto
{
    public int Id { get; init; }
    public required string Email { get; init; }
    public int? OrderId { get; init; }
    public DateTime DateOfEvent { get; init; }
    public DateTime ReservedOn { get; init; }
    public required string ReservationStatus { get; init; }
    public required EventType EventType { get; init; }
    public required string EventDescription { get; init; }
    public required string EventAddressLine1 { get; init; }
    public string? EventAddressLine2 { get; init; }
    public required string EventCity { get; init; }
    public required string EventPostalCode { get; init; }
    public required string EventState { get; init; }
    public required string EventCountry { get; init; }
    public decimal? ServicePrice { get; init; }
}