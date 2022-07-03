namespace FlowerShop.ApplicationServices.API.Domain.User
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;
    using System;

    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public int UserId;
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
    }
}