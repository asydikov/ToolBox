using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Messages.Events.Notification;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.SQLMonitor.Handlers.DbWorker
{
    public class DbWorkerOperationCompletedHandler : IEventHandler<DbWorkerOperationCompleted>
    {
        private readonly IBusClient _busClient;
        private readonly IMetricsProcessingService _metricsProcessingService;
        private readonly ILogger _logger;
        public DbWorkerOperationCompletedHandler(IBusClient busClient,
            IMetricsProcessingService metricsProcessingService,
         ILogger<DbWorkerOperationCompleted> logger)
        {
            _busClient = busClient;
            _metricsProcessingService = metricsProcessingService;
            _logger = logger;
        }
        public async Task HandleAsync(DbWorkerOperationCompleted command)
        {
            if (command.Resource != "sqlmonitor-service")
            {
                return;
            }
            await _metricsProcessingService.ProcessMetrics(command);

            //_logger.LogInformation($"sqlmonitor DbWorkerOperationCompleted: {command.SqlQueryName}");

            await _busClient.PublishAsync(new OperationCompleted(command.Id, command.UserId, "sqlmonitor-service", "database-metrics-updated"));
        }
    }
}
