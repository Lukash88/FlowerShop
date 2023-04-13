using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    public class AddDecorationRequest : IRequest<AddDecorationResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Role { get; set; }
        public bool IsAvailable { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }
    }
}