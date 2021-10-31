namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;

    public class UserDTO
    {
        public int Id { get; set; }
        public UserRole Roles { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }       
        public string City { get; set; }
    }
}
