namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;

    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public object LongDescription { get; internal set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }
    }
}