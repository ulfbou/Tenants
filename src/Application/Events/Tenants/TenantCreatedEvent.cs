using MediatR;

using Microsoft.Extensions.Logging;

using Tenants.Application.Events.Tenants;

namespace Tenants.Application.Events.Tenants
{
    public class TenantCreatedEvent : INotification
    {
        public Guid TenantId { get; set; }
        public string TenantName { get; set; }
    }
    public class TenantCreatedEventHandler : INotificationHandler<TenantCreatedEvent>
    {
        private readonly ILogger<TenantCreatedEventHandler> _logger;

        public TenantCreatedEventHandler(ILogger<TenantCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TenantCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Tenant created: {notification.TenantName} (ID: {notification.TenantId})");
            return Task.CompletedTask;
        }
    }
}
