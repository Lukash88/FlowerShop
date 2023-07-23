using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    public class GetFlowerByIdRequest : IRequest<GetFlowerByIdResponse>
    {
        public int FlowerId { get; init; }
    }
}