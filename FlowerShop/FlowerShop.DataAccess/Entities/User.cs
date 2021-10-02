using FlowerShop.DataAccess.Enums;
using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class User : EntityBase
    {
        public UserRole Roles { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
