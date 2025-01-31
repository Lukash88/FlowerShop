namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class DeliveryMethodDto
{
    public int Id { get; init; }
    public required string ShortName { get; init; }
    public required string DeliveryTime { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
}