using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Services.Notification.Messages.Events;
using ToolBox.Services.Notification.Services;

namespace ToolBox.Services.Notification.Handlers
{
    public class ServerMemoryUsageMetricsHandler : IEventHandler<ServerMemoryUsageMetrics>
    {
        private readonly IHubService _hubService;
        private readonly ILogger _logger;
        public ServerMemoryUsageMetricsHandler(
         IHubService hubService,
         ILogger<ServerMemoryUsageMetricsHandler> logger)
        {
            _hubService = hubService;
            _logger = logger;
        }


        public async Task HandleAsync(ServerMemoryUsageMetrics @event)
        {
            _logger.LogInformation($"Processing event: {@event.Id}");

            try
            {
                await _hubService.PublishServerMemoryUsageMetricsAsync(@event);
            }
            catch (Exception ex)
            {
                _logger.LogError(@event.Id.ToString(), ex.Message);
            }
        }
    }
}
