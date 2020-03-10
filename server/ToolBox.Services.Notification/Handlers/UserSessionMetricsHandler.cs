using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ToolBox.Common.Events;
using ToolBox.Services.Notification.Messages.Events;
using ToolBox.Services.Notification.Services;

namespace ToolBox.Services.Notification.Handlers
{
    public class UserSessionMetricsHandler : IEventHandler<UserSessionMetrics>
    {
        private readonly IHubService _hubService;
        private readonly ILogger _logger;
        public UserSessionMetricsHandler(
         IHubService hubService,
         ILogger<UserSessionMetricsHandler> logger)
        {
            _hubService = hubService;
            _logger = logger;
        }


        public async Task HandleAsync(UserSessionMetrics @event)
        {
            _logger.LogInformation($"Processing event: {@event.Id}");
            try
            {
                await _hubService.PublishUserSessionMetricsAsync(@event);
            }
            catch (Exception ex)
            {
                _logger.LogError(@event.Id.ToString(), ex.Message);
            }
        }
    }
}
