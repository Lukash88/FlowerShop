using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
    {
        public int OrderId;
    }
}