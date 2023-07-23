using System;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        public int OrderId;
        public int UserId { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public string Invoice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
        public int Quantity { get; set; }
        public decimal? Sum { get; set; }
    }
}