namespace FlowerShop.ApplicationServices.API.Domain.User
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public UserRole Roles { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
