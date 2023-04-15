using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Basket
{
    public class RemoveBasketRequest : IRequest<RemoveBasketResponse>
    {
        public string BasketId { get; init; }
    }
}