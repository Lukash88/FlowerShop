using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class OrderDetail : EntityBase
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}