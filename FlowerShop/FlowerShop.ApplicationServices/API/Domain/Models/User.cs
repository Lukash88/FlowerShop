using FlowerShop.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public UserRole Roles { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }       
        public string City { get; set; }
    }
}
