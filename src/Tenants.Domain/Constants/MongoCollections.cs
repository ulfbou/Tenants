namespace Tenants.Domain.Constants;

public static class MongoCollections
{
    public const string Tenants = nameof(Tenants);
    public const string Users = nameof(Users);
    public const string Roles = nameof(Roles);
    public const string Permissions = nameof(Permissions);
    public const string TenantUsers = nameof(TenantUsers);
    public const string TenantRoles = nameof(TenantRoles);
    public const string TenantPermissions = nameof(TenantPermissions);
    public const string Configurations = nameof(Configurations);
    public const string AuditLogs = nameof(AuditLogs);
    public const string Notifications = nameof(Notifications);
}
