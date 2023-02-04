namespace FlowerShop.DataAccess.Entities
{
    using FlowerShop.DataAccess.Enums;

    public class BasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public Category? Category { get; set; }
    }
}