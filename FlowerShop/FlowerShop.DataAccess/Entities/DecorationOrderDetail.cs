namespace FlowerShop.DataAccess.Entities
{
    public class DecorationOrderDetail
    {
        public int DecorationId { get; set; }
        public Decoration Decoration { get; set; }
        public int DecorationQuantity { get; set; }

        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
