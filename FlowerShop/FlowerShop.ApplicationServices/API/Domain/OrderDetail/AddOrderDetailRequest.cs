﻿namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;
    using System;

    public class AddOrderDetailRequest : IRequest<AddOrderDetailResponse>
    {        
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
        public int ReservationId { get; set; }
    }
}
