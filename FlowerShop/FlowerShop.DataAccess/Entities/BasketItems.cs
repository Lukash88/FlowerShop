namespace FlowerShop.DataAccess.Entities
{
    using FlowerShop.DataAccess.Enums;

    public class BasketItems : EntityBase
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public Category? Category { get; set; }
    }
}