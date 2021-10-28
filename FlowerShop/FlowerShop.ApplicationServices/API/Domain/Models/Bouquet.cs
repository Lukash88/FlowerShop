namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;

    public class Bouquet
    {
        public int Id { get; set; }
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public int Quantity { get; set; }
        public DecorationWay DecorationWay { get; set; }
    }
}
