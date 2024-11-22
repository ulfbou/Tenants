namespace Tenants.Domain.Exceptions;

[Serializable]
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() { }

    public EntityNotFoundException(string? message) : base(message) { }

    public EntityNotFoundException(string entityName, Guid id) : base($"Entity '{entityName}' with id '{id}' was not found.") { }

    public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
}