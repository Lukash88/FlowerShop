using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    public class GetReservationByIdRequest : IRequest<GetReservationByIdResponse>
    {
        public int ReservationId { get; init; }
    }
}