﻿using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public required string DisplayName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public Gender? Gender { get; init; }
    public required string Email { get; set; }
    public string? NewEmail { get; init; }
    public string? NewPassword { get; init; }
    public string? ExistingPassword { get; init; }
}