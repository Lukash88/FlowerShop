using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string EventStreet { get; set; }
        public string EventCity { get; set; }
        public string EventPostalCode { get; set; }
    }
}
