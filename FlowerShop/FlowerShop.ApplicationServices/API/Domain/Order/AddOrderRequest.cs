namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;
    using System;

    public class AddOrderRequest : IRequest<AddOrderResponse>
    {
        public int UserId { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public string Invoice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
        public int Quantity { get; set; }
        public decimal? Sum { get; set; }
    }
}