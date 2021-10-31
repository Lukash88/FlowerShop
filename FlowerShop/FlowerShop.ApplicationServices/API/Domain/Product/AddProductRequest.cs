using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Category { get; set; }
    }
}
