namespace FlowerShop.ApplicationServices.API.Domain.OrderItem
{
    using MediatR;

    public class GetOrderItemsRequest : IRequest<GetOrderItemsResponse>
    {
        public string Name { get; init; }
    }
}
