namespace FlowerShop.ApplicationServices.API.Domain.OrderItem
{
    using MediatR;

    public class AddOrderItemRequest : IRequest<AddOrderItemResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int OrderDetailId { get; set; }
    }
}
