using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    public class GetOrderDetailByIdRequest : IRequest<GetOrderDetailByIdResponse>
    {
        public int OrderDetailId;
    }
}