using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration;

public class UpdateDecorationRequest : UpdateProductRequest, IRequest<UpdateDecorationResponse>
{
    public required int DecorationId;
    public DecorationRole Role { get; set; }
}