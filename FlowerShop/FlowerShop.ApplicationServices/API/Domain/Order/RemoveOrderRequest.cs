namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    using MediatR;

    public class RemoveOrderRequest : IRequest<RemoveOrderResponse>
    {
        public int OrderId;
    }
}