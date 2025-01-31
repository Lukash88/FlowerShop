using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class RegisterAppUserRequest : IRequest<RegisterAppUserResponse>
{
    public required string DisplayName { get; init; }
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Password { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public Gender? Gender { get; init; }
    public string? Street { get; init; }
    public string? PostalCode { get; init; }
    public string? City { get; init; }
}