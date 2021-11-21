namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class GetReservationsRequest : IRequest<GetReservationsResponse>
    {
        public EventType EventType { get; init; }
    }
}