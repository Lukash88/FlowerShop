namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System.Collections.Generic;

    public class UserDTO
    {
        public int Id { get; set; }
        public UserRole Roles { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }       
        public string City { get; set; }      
        public string Street { get; set; }
        public string PostalCode { get; set; }        

        public List<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();
    }
}
