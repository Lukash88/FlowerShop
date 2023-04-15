using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    public class UpdateOrderDetailRequest : IRequest<UpdateOrderDetailResponse>
    {
        public int OrderDetailId;
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
    }
}