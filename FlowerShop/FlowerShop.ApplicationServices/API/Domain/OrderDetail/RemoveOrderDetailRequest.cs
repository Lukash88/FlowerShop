namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using MediatR;

    public class RemoveOrderDetailRequest : IRequest<RemoveOrderDetailResponse>
    {
        public int OrderDetailId { get; set; }
    }
}
