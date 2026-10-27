using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class UpdateReservationForUserRequest : IRequest<UpdateReservationResponse>
{
    public required int Id;
    public required string Email { get; set; }
    public int? OrderId { get; init; }
    public DateTime DateOfEvent { get; init; }
    public DateTime ReservedOn { get; init; }
    public required ReservationState ReservationStatus { get; init; }
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