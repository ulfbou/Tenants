using Tenants.Application.DTOs;
using Tenants.Domain.Entities;

namespace Tenants.Application.Mappings;

public static class EntityExtensions
{
    public static TenantResponseDto AsResponse(this Tenant tenant)
    {
        return new TenantResponseDto(tenant.TenantId, tenant.Name, tenant.Description);
    }

    public static IEnumerable<TenantResponseDto> AsResponse(this IEnumerable<Tenant> tenants)
    {
        return tenants.Select(t => t.AsResponse());
    }

    public static PermissionResponseDto AsResponse(this Permission permission)
    {
        return new PermissionResponseDto(permission.PermissionId, permission.Name, permission.Description, permission.Category);
    }

    public static IEnumerable<PermissionResponseDto> AsResponse(this IEnumerable<Permission> permissions)
    {
        return permissions.Select(p => p.AsResponse());
    }

    public static TenantPermissionResponseDto AsResponse(this TenantPermission tenantPermission)
    {
        return new TenantPermissionResponseDto(tenantPermission.TenantId, tenantPermission.PermissionId, tenantPermission.Name, tenantPermission.Description, tenantPermission.Category);
    }

    public static IEnumerable<TenantPermissionResponseDto> AsResponse(this IEnumerable<TenantPermission> tenantPermissions)
    {
        return tenantPermissions.Select(tp => tp.AsResponse());
    }

    public static RoleResponseDto AsResponse(this Role role)
    {
        return new RoleResponseDto(role.GetIdentifier(), role.Name, role.Description);
    }

    public static IEnumerable<RoleResponseDto> AsResponse(this IEnumerable<Role> roles)
    {
        return roles.Select(r => r.AsResponse());
    }

    public static UserResponseDto AsResponse(this User user)
    {
        return new UserResponseDto(user.GetIdentifier(), user.UserName);
    }

    public static IEnumerable<UserResponseDto> AsResponse(this IEnumerable<User> users)
    {
        return users.Select(u => u.AsResponse());
    }

    public static TenantRoleResponseDto AsResponse(this TenantRole tenantRole)
    {
        return new TenantRoleResponseDto(tenantRole.GetIdentifier(), tenantRole.TenantId, tenantRole.Name, tenantRole.Description);
    }

    public static IEnumerable<TenantRoleResponseDto> AsResponse(this IEnumerable<TenantRole> tenantRoles)
    {
        return tenantRoles.Select(tr => tr.AsResponse());
    }
}