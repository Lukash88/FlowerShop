using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower;

public class RemoveFlowerRequest : IRequest<RemoveFlowerResponse>
{
    public required int FlowerId { get; init; }
}