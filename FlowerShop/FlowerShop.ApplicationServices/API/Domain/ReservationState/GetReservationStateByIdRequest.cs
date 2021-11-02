namespace FlowerShop.ApplicationServices.API.Domain.ReservationState
{
    using MediatR;

    public class GetReservationStateByIdRequest : IRequest<GetReservationStateByIdResponse>
    {
        public int ReservationStateId { get; init; }
    }
}
