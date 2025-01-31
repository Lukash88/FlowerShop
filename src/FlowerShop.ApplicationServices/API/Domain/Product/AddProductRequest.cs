using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product;

public class AddProductRequest : IRequest<AddProductResponse>
{
    public required string Name { get; init; }
    public required string ShortDescription { get; init; }
    public required string LongDescription { get; init; }
    public Category Category { get; init; }
    public required decimal Price { get; init; } 
    public required string ImageUrl { get; init; }
    public required string ImageThumbnailUrl { get; init; }
    public int StockLevel { get; init; }
}