using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Messages.Events;

namespace ToolBox.Services.SQLMonitor.Handlers
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
            if (command.Resource != "sqlmonitor-service")
            {
                return;
            }

            _logger.LogError($"DbWorkerOperationRejected: {command.Id}, {command.Message}");

        }
    }
}
