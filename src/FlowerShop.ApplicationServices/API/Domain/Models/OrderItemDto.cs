namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderItemDto
    {
        public int ProductId { get; init; }
        public decimal Price { get; init; }
        public string ProductName { get; init; }
        public string ImageUrl { get; init; }
        public int Quantity { get; init; }
    }
}