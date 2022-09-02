namespace FlowerShop.DataAccess.Entities
{
    public class BouquetOrderDetail
    {
        public int BouquetId { get; set; }
        public Bouquet Bouquet { get; set; }
        public int BouquetQuantity { get; set; }

        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
