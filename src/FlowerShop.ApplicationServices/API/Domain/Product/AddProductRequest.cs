using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Category Category { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockLevel { get; set; }
    }
}