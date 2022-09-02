namespace FlowerShop.DataAccess.Entities
{
    public class BouquetFlower
    {
        public int BouquetId { get; set; }
        public Bouquet Bouquet { get; set; }

        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
        public int FlowerQuantity { get; set; }
    }
}