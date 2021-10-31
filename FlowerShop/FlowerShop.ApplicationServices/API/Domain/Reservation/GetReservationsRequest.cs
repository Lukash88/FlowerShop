namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using MediatR;

    public class GetReservationsRequest : IRequest<GetReservationsResponse>
    {
        public string EventType { get; init; }
    }
}
