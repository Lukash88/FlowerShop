namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using MediatR;

    public class AddOrderDetailRequest : IRequest<AddOrderDetailResponse>
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
    }
}