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
    public class DatabaseSpaceUsageMetricsHandler : IEventHandler<DatabaseSpaceUsageMetricsCompleted>
    {
        private readonly IHubService _hubService;
        private readonly ILogger _logger;
        public DatabaseSpaceUsageMetricsHandler(
         IHubService hubService,
         ILogger<DatabaseSpaceUsageMetricsHandler> logger)
        {
            _hubService = hubService;
            _logger = logger;
        }


        public async Task HandleAsync(DatabaseSpaceUsageMetricsCompleted @event)
        {
            _logger.LogInformation($"Processing event: {@event.Id}");

            try
            {
                await _hubService.PublishDatabaseSpaceMetricsEventAsync(@event);
            }
            catch (Exception ex)
            {
                _logger.LogError(@event.Id.ToString(), ex.Message);
            }
        }
    }
}
