using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public Gender? Gender { get; init; }
    public required string Email { get; set; }
    public string? NewEmail { get; init; }
    public string? NewPassword { get; init; }
}