using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RawRabbit;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Messages.Events.Notification;

namespace ToolBox.Services.SQLMonitor.Services
{

    public class MetricsProcessingService : IMetricsProcessingService
    {
        private readonly IBusClient _busClient;
        private readonly IServerService _serverService;
        private readonly IDatabaseService _databaseService;

        private readonly IDatabaseBackupMetricsService _databaseBackupMetricsService;
        private readonly IDatabaseSpaceMetricsService _databaseSpaceMetricsService;
        private readonly IMemoryUsageMetricsService _memoryUsageMetricsService;

        public MetricsProcessingService(
            IBusClient busClient,
            IServerService serverService,
            IDatabaseService databaseService,
            IDatabaseBackupMetricsService databaseBackupMetricsService,
            IDatabaseSpaceMetricsService databaseSpaceMetricsService,
            IMemoryUsageMetricsService memoryUsageMetricsService
            )
        {
            _busClient = busClient;
            _serverService = serverService;
            _databaseService = databaseService;
            _databaseBackupMetricsService = databaseBackupMetricsService;
            _databaseSpaceMetricsService = databaseSpaceMetricsService;
            _memoryUsageMetricsService = memoryUsageMetricsService;
        }
        public async Task ProcessMetrics(DbWorkerOperationCompleted command)
        {
            if (command.SqlQueryName == (int)SqlQueryNames.DatabaseSpaceStatus)
            {
                await DatabaseSpaceMetricCollect(command);
            }

            if (command.SqlQueryName == (int)SqlQueryNames.DatabasesBackupStatus)
            {
                await DatabaseBackupMetricCollect(command);
            }

            if (command.SqlQueryName == (int)SqlQueryNames.ConnectedUsers)
            {
                await UserSessionMetricCollect(command);
            }

            if (command.SqlQueryName == (int)SqlQueryNames.MemoryUsage)
            {
                await MemoryUsageMetricCollect(command);
            }
        }

        private async Task DatabaseSpaceMetricCollect(DbWorkerOperationCompleted command)
        {
            var databaseSpaceMetrics = new DatabaseSpaceMetricsModel();
            var flatResult = command.Result.SelectMany(x => x).Where(x => x.Key == "database_size" || x.Key == "unallocated space");
            var databaseSize = flatResult.FirstOrDefault(x => x.Key == "database_size").Value.Split();
            databaseSpaceMetrics.DatabaseId = command.DatabaseId;
            databaseSpaceMetrics.Space = Convert.ToDouble(flatResult.FirstOrDefault(x => x.Key == "database_size").Value.Split()[0]);
            databaseSpaceMetrics.UnallocatedSpace = Convert.ToDouble(flatResult.FirstOrDefault(x => x.Key == "unallocated space").Value.Split()[0]);
            databaseSpaceMetrics.Unit = "MB";

            await _databaseSpaceMetricsService.CreateAsync(databaseSpaceMetrics);

            await _busClient.PublishAsync(new DatabaseSpaceMetricsEvent(
                command.Id,
                command.UserId,
                databaseSpaceMetrics.DatabaseId,
                databaseSpaceMetrics.Space,
                databaseSpaceMetrics.UnallocatedSpace,
                databaseSpaceMetrics.Unit
                ));
        }

        private async Task DatabaseBackupMetricCollect(DbWorkerOperationCompleted command)
        {
            var databases = await _databaseService.GetAllAsync(x => x.ServerId == command.SqlServerId);
            var models = new List<DatabaseBackupMetricsModel>();

            foreach (var result in command.Result)
            {
                var databaseBackupMetrics = new DatabaseBackupMetricsModel();
                var full = result["full DB Backup Status"];
                var transaction = result["transaction DB Backup Status"];
                var differential = result["differential DB Backup Status"];
                var dbName = result["databasE_Name"];

                databaseBackupMetrics.Full = !string.IsNullOrWhiteSpace(full) ? DateTime.Parse(full) : (DateTime?)null;
                databaseBackupMetrics.Transaction = !string.IsNullOrWhiteSpace(transaction) ? DateTime.Parse(transaction) : (DateTime?)null;
                databaseBackupMetrics.Differential = !string.IsNullOrWhiteSpace(differential) ? DateTime.Parse(differential) : (DateTime?)null;
                databaseBackupMetrics.RecoveryModel = result["recoveryModel"];
                databaseBackupMetrics.DatabaseId = databases.FirstOrDefault(x => x.Name == dbName).Id;
                models.Add(databaseBackupMetrics);
            }

            await _databaseBackupMetricsService.AddRangeAsync(models);
        }

        private async Task UserSessionMetricCollect(DbWorkerOperationCompleted command)
        {
            var flatResults =
                command.Result.SelectMany(x => x)
                    .Where(x => x.Key == "login_name" && x.Value != "");

            var connectedUsers = new List<string>();

            foreach (var result in flatResults)
            {
                connectedUsers.Add(result.Value);
            }

            await _busClient.PublishAsync(new UserSessionMetrics(
                command.Id,
                command.UserId,
                command.SqlServerId,
                connectedUsers
            ));
        }

        private async Task MemoryUsageMetricCollect(DbWorkerOperationCompleted command)
        {
            var memoryUsageMetrics = new MemoryUsageMetricsModel
            {
                RequestsCount = Convert.ToInt32(command.Result[0]["cntr_value"]),
                PageReadsCount = Convert.ToInt32(command.Result[1]["cntr_value"]),
                PageLifetime = Convert.ToInt32(command.Result[2]["cntr_value"]),
                ServerId = command.SqlServerId
            };

            await _memoryUsageMetricsService.CreateAsync(memoryUsageMetrics);

            await _busClient.PublishAsync(new ServerMemoryUsageMetrics(
                command.Id,
                command.UserId,
                memoryUsageMetrics.ServerId,
                memoryUsageMetrics.RequestsCount,
                memoryUsageMetrics.PageReadsCount,
                memoryUsageMetrics.PageLifetime
            ));
        }
    }
}
