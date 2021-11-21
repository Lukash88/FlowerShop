namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
        public OrderState OrderState { get; set; }
    }
}