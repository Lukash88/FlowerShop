namespace FlowerShop.DataAccess.Entities
{
    public class ProductOrderDetail
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }

        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}