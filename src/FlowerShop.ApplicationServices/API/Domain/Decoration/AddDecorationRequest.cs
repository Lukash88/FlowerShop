using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    public class AddDecorationRequest : AddProductRequest, IRequest<AddDecorationResponse>
    {
        public DecorationRole Role { get; init; }
    }
}