using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class BasketItemDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string ShortDescription { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public string ImageUrl { get; init; }
        public Category? Category { get; init; }
    }
}