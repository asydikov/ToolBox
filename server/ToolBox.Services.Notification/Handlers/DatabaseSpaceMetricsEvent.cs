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
    public class DatabaseSpaceMetricsEventHandler : IEventHandler<DatabaseSpaceMetricsEvent>
    {
        private readonly IHubService _hubService;
        private readonly ILogger _logger;
        public DatabaseSpaceMetricsEventHandler(
         IHubService hubService,
         ILogger<DatabaseSpaceMetricsEventHandler> logger)
        {
            _hubService = hubService;
            _logger = logger;
        }


        public async Task HandleAsync(DatabaseSpaceMetricsEvent @event)
        {
            await _hubService.PublishDatabaseSpaceMetricsEventAsync(@event);
        }
    }
}
