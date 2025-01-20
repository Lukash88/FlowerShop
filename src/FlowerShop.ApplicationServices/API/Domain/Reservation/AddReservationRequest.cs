using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class AddReservationRequest : IRequest<AddReservationResponse>
{
    public required int OrderId { get; init; }
    public DateTime DateOfEvent { get; init; }
    public DateTime ReservedOn { get; init; }
    public required ReservationState ReservationStatus { get; init; }
    public required EventType EventType { get; init; }
    public required string EventDescription { get; init; }
    public required string EventStreet { get; init; }
    public required string EventCity { get; init; }
    public required string EventPostalCode { get; init; }
    public decimal? ServicePrice { get; init; }
}