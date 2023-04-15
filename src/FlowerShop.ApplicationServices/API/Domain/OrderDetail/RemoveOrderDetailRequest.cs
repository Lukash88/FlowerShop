using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    public class RemoveOrderDetailRequest : IRequest<RemoveOrderDetailResponse>
    {
        public int OrderDetailId;
    }
}