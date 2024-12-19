namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string ShortDescription { get; init; }
        public string LongDescription { get; init; }
        public string Category { get; init; }
        public decimal Price { get; init; }
        public string ImageUrl { get; init; }
        public string ImageThumbnailUrl { get; init; }
        public int StockLevel { get; init; }
    }
}