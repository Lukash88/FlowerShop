using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;

public class UpdateDeliveryMethodRequest : IRequest<UpdateDeliveryMethodResponse>
{
    public required int MethodId;
    public required string ShortName { get; init; }
    public required string DeliveryTime { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
}