using Microsoft.Extensions.Logging;

using Tenants.Application.DTOs;
using Tenants.Application.Interfaces;
using Tenants.Domain.Common;
using Tenants.Domain.Constants;
using Tenants.Domain.Entities;
using Tenants.Domain.Interfaces;

namespace Tenants.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly ILogger<PermissionService> _logger;

    public PermissionService(IPermissionRepository permissionRepository, ILogger<PermissionService> logger)
    {
        _permissionRepository = permissionRepository;
        _logger = logger;
    }

    public async Task<PermissionResponseDto> CreatePermissionAsync(PermissionCreateDto permissionCreateDto, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating a new permission with Name: {Name}", permissionCreateDto.Name);
        var permission = new Permission(permissionCreateDto.Name, permissionCreateDto.Description, permissionCreateDto.Category);
        await _permissionRepository.AddAsync(permission, cancellationToken);

        return new PermissionResponseDto(permission.GetIdentifier(), permission.Name, permission.Description, permission.Category);
    }

    public async Task<IEnumerable<PermissionResponseDto>> GetAllPermissionsAsync(string? search, PaginationParameters? pagination, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Retrieving all permissions");
        var permissions = await _permissionRepository.GetAllAsync(search, pagination, cancellationToken);

        return permissions.Select(p => new PermissionResponseDto(p.PermissionId, p.Name, p.Description, p.Category));
    }

    public async Task<PermissionResponseDto> UpdatePermissionAsync(Guid id, PermissionCreateDto permissionCreateDto, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating permission with Id: {Id}", id);
        var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);

        if (permission == null)
        {
            _logger.LogWarning("Permission with Id: {Id} not found", id);
            throw new KeyNotFoundException($"Permission with Id: {id} not found");
        }

        permission.Name = permissionCreateDto.Name;
        permission.Description = permissionCreateDto.Description;
        permission.Category = permissionCreateDto.Category;
        permission.LastModifiedAt = DateTime.UtcNow;

        await _permissionRepository.UpdateAsync(permission, cancellationToken);

        return new PermissionResponseDto(permission.GetIdentifier(), permission.Name, permission.Description, permission.Category);
    }

    public async Task DeletePermissionAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Deleting permission with Id: {Id}", id);
        var permission = await _permissionRepository.GetByIdAsync(id, cancellationToken);

        if (permission == null)
        {
            _logger.LogWarning("Permission with Id: {Id} not found", id);
            throw new KeyNotFoundException($"Permission with Id: {id} not found");
        }

        await _permissionRepository.DeleteAsync(permission, cancellationToken);
    }

    public async Task SetupDefaultPermissionsAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Setting up default permissions for tenant with Id: {TenantId}", tenantId);

        var permissions = new List<Permission>
        {
            new Permission(Permissions.Users.Create, "Create a new user", "User"),
            new Permission(Permissions.Users.Edit, "Update an existing user", "User"),
            new Permission(Permissions.Users.Delete, "Delete an existing user", "User"),
            new Permission(Permissions.Users.View, "View an existing user", "User"),
            new Permission(Permissions.Roles.Create, "Create a new role", "Role"),
            new Permission(Permissions.Roles.Edit, "Update an existing role", "Role"),
            new Permission(Permissions.Roles.Delete, "Delete an existing role", "Role"),
            new Permission(Permissions.Roles.View, "View an existing role", "Role"),
            new Permission(Permissions.PermissionsManagement.Create, "Create a new permission", "Permission"),
            new Permission(Permissions.PermissionsManagement.Edit, "Update an existing permission", "Permission"),
            new Permission(Permissions.PermissionsManagement.Delete, "Delete an existing permission", "Permission"),
            new Permission(Permissions.PermissionsManagement.View, "View an existing permission", "Permission"),
        };

        foreach (var permission in permissions)
        {
            await _permissionRepository.AddAsync(permission, cancellationToken);
        }
    }
}