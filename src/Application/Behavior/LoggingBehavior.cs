using MediatR;

using Microsoft.Extensions.Logging;

using System.Diagnostics;
using System.Text.Json;

using Tenants.Application.Commands;
using Tenants.Domain.Utilities;

namespace Tenants.Application.Behavior
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
        {
            ArgumentGuard.NotNull(request, nameof(request));

            var requestName = typeof(TRequest).Name;
            var requestGuid = Guid.NewGuid().ToString();
            var requestNameWithGuid = $"{requestName} [{requestGuid}]";

            using var scope = _logger.BeginScope(new Dictionary<string, object> { { "RequestId", requestGuid }, { "RequestName", requestName } });

            _logger.LogInformation("Handling {RequestName} with payload: {@Request}", requestNameWithGuid, request);

            var stopwatch = Stopwatch.StartNew();

            try
            {
                try
                {
                    _logger.LogDebug("[PROPS] {RequestName} Payload: {Payload}", requestNameWithGuid, JsonSerializer.Serialize(request));
                }
                catch (NotSupportedException ex)
                {
                    _logger.LogWarning(ex, "[Serialization ERROR] Could not serialize the request {RequestName}.", requestNameWithGuid);
                }

                var response = await next();
                stopwatch.Stop();

                _logger.LogInformation(
                    "Handled {RequestName} in {ElapsedMilliseconds}ms with response: {@Response}",
                    requestNameWithGuid,
                    stopwatch.ElapsedMilliseconds,
                    response);

                return response;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                _logger.LogError(
                    ex,
                    "Error handling {RequestName} after {ElapsedMilliseconds}ms. Request: {@Request}",
                    requestNameWithGuid,
                    stopwatch.ElapsedMilliseconds,
                    request);

                throw;
            }
        }
    }
}