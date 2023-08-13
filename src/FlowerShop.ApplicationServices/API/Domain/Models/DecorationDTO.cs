using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class DecorationDto : ProductDto
    {
        public DecorationRole Role { get; init; }
    }
}