using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class UserResponseDto : UserCreateDto, IResponseDto
{
    public Guid UserId { get; set; }

    public UserResponseDto(Guid userId, string? username) : base(username)
    {
        UserId = userId;
    }
}