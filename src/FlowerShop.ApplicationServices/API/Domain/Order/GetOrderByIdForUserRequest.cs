using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public sealed class GetOrderByIdForUserRequest : IRequest<GetOrderByIdForUserResponse>
    {
        public string BuyerEmail;
        public int OrderId { get; init; }
    }
}