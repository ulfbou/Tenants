namespace Tenants.Domain.Interfaces;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedAt { get; set; }
    Guid CreatedBy { get; set; }
    bool IsDeleted { get; set; }
    DateTime? LastModifiedAt { get; set; }
    Guid? UpdatedBy { get; set; }
}