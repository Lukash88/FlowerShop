using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower;

public class GetFlowerByIdRequest : IRequest<GetFlowerByIdResponse>
{
    public required int FlowerId { get; init; }
}