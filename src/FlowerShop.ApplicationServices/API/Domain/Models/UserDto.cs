namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class UserDto
    {
        public string Email { get; init; } 
        public string DisplayName { get; init; }
        public string Token { get; set; }
    }
}