using FlowerShop.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
    }
}
