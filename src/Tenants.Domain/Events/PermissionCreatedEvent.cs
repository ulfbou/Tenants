using Tenants.Domain.Common;

namespace Tenants.Domain.Events;

public class PermissionCreatedEvent : BaseEvent
{
    public PermissionCreatedEvent(Guid permissionId, Guid tenantId, string name, string description)
    {
        PermissionId = permissionId;
        TenantId = tenantId;
        Name = name;
        Description = description;
    }

    public Guid PermissionId { get; }
    public Guid TenantId { get; }
    public string Name { get; }
    public string Description { get; }
}