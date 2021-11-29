namespace FlowerShop.DataAccess.Entities
{
    using FlowerShop.DataAccess.Enums;
    using System;
    using System.Collections.Generic;

    public class Order : EntityBase
    {        
        public bool IsPaymentConfirmed { get; set; }
        public string Invoice { get; set; }                                                  
        public DateTime? CreatedAt { get; set; }                                                         
        public OrderState OrderState { get; set; }            
        public int Quantity { get; set; }
        public decimal? Sum { get; set; }

        //public int? ReservationId { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();                                          
                                                                                                        
        public int UserId { get; set; }
        public User User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}