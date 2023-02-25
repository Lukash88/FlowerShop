using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class UserDTO
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }        
        public string City { get; set; }      

        //public List<string> Orders { get; set; } = new List<string>();
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}