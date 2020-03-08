using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Messages.Events;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Messages.Events.Notification;

namespace ToolBox.Services.SQLMonitor.Handlers.DbWorker
{
    public class DbWorkerOperationRejectedHandler : IEventHandler<DbWorkerOperationRejected>
    {
        private readonly IBusClient _busClient;
        private readonly ILogger _logger;
        public DbWorkerOperationRejectedHandler(IBusClient busClient,
         ILogger<DbWorkerOperationRejectedHandler> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }
        public async Task HandleAsync(DbWorkerOperationRejected command)
        {
            await _busClient.PublishAsync(new OperationRejected(
                command.Id,
                command.UserId,
                command.SqlServerId,
                command.Message,
                "sqlmonitor",
                "login_failed",
                command.Message
            ));

            _logger.LogError($"DbWorkerOperationRejected: {command.Id}, {command.Message}");

        }
    }
}
