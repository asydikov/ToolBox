﻿using Microsoft.Extensions.Logging;
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
    public class OperationCompletedHandler : IEventHandler<OperationCompleted>
    {
        private readonly IHubService _hubService;
        private readonly ILogger _logger;
        public OperationCompletedHandler(
         IHubService hubService,
         ILogger<OperationCompletedHandler> logger)
        {
            _hubService = hubService;
            _logger = logger;
        }


        public async Task HandleAsync(OperationCompleted @event)
        {
            _logger.LogInformation($"Notification service event handler. Sending notificationto user: {@event.UserId}");
            await _hubService.PublishOperationCompletedAsync(@event);
        }
    }
}