namespace FlowerShop.ApplicationServices.API.Domain.OrderItem
{
    using MediatR;

    public class RemoveOrderItemRequest : IRequest<RemoveOrderItemResponse>
    {
        public int OrderItemId;
    }
}
