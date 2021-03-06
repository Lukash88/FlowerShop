namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;

    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int ProductId;
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }
    }
}