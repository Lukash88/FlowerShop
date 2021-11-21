namespace FlowerShop.DataAccess.Entities
{
    using FlowerShop.DataAccess.Enums;
    using System.Collections.Generic;

    public class Bouquet : EntityBase
    {
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public List<Flower> Flowers { get; set; } = new List<Flower>(); 
    }
}