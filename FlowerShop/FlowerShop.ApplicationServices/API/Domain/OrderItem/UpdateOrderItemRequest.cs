namespace FlowerShop.ApplicationServices.API.Domain.OrderItem
{
    using MediatR;

    public class UpdateOrderItemRequest : IRequest<UpdateOrderItemResponse>
    {
        public int OrderItemId;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int OrderDetailId { get; set; }
    }
}
