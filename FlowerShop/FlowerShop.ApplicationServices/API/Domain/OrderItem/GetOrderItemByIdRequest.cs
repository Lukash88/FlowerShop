namespace FlowerShop.ApplicationServices.API.Domain.OrderItem
{
    using MediatR;

    public class GetOrderItemByIdRequest : IRequest<GetOrderItemByIdResponse>
    {
        public int OrderItemId;
    }
}
