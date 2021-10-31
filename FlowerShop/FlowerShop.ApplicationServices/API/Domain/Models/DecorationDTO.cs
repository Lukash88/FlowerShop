namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;

    public class DecorationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Roles { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
