using System;
using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class Order : EntityBase
    {        
        public bool IsPaymentConfirmed { get; set; }
        public string Invoice { get; set; }                                                  
        public DateTime? CreatedAt { get; set; }                                                         
        public OrderState OrderState { get; set; }            
        public int Quantity { get; set; }
        public decimal? Sum { get; set; }
        
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();      
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}