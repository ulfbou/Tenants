namespace Tenants.Domain.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string? message) : base(message) { }
        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
        public EntityNotFoundException(Guid entityId, string name) : base($"Entity with id {entityId} and name {name} not found") { }
    }
}