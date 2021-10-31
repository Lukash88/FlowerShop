namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using MediatR;

    public class GetReservationByIdRequest : IRequest<GetReservationByIdResponse>
    {
        public int ReservationId { get; init; }
    }
}
