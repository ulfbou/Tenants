using Tenants.Application.Interfaces;

namespace Tenants.Application.DTOs;

public class UserCreateDto : ICreateDto
{
    public string? Username { get; set; }

    public UserCreateDto(string? username)
    {
        Username = username;
    }
}