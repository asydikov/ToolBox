﻿using Microsoft.Extensions.Logging;
using RawRabbit;
using System.Threading.Tasks;
using ToolBox.Common.Events;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.SQLMonitor.Handlers.DbWorker
{
    public class DbWorkerOperationCompletedHandler : IEventHandler<DbWorkerOperationCompleted>
    {
        private readonly IBusClient _busClient;
        private readonly IMetricsProcessingService _metricsProcessingService;
        private readonly IDatabaseService _databaseService;
        private readonly ILogger _logger;
        public DbWorkerOperationCompletedHandler(IBusClient busClient,
            IMetricsProcessingService metricsProcessingService,
            IDatabaseService databaseService,
            ILogger<DbWorkerOperationCompleted> logger)
        {
            _busClient = busClient;
            _metricsProcessingService = metricsProcessingService;
            _databaseService = databaseService;
            _logger = logger;
        }
        public async Task HandleAsync(DbWorkerOperationCompleted command)
        {
            if (command.Resource != "sqlmonitor-service")
            {
                return;
            }

            if (command.SqlQueryName == (int)SqlQueryNames.DatabaseNames)
            {
                await _databaseService.AddDatabases(command);
            }
            else
            {
                await _metricsProcessingService.ProcessMetrics(command);
            }
        }
    }
}
