using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;

namespace ToolBox.Services.SQLMonitor.Services
{
    
    public class MetricsProcessingService : IMetricsProcessingService
    {
        private readonly IServerService _serverService;
        private readonly IDatabaseService _databaseService;
        public MetricsProcessingService(
            IServerService serverService,
            IDatabaseService databaseService)
        {
            _serverService = serverService;
            _databaseService = databaseService;
        }
        public async Task ProcessMetrics(DbWorkerOperationCompleted command)
        {
            if (command.SqlQueryName == (int)SqlQueryNames.DatabaseSpaceStatus)
            {
                DatabaseSpaceMetricCollect(command);
            }

            if (command.SqlQueryName == (int)SqlQueryNames.DatabasesBackupStatus)
            {
                await DatabaseBackupMetricCollect(command);
            }

            if (command.SqlQueryName == (int)SqlQueryNames.ConnectedUsers)
            {
                USerSessionMetricCollect(command);
            }

            if (command.SqlQueryName == (int)SqlQueryNames.MemoryUsage)
            {
                MemoryUsageMetricCollect(command);
            }

        }

        private static void DatabaseSpaceMetricCollect(DbWorkerOperationCompleted command)
        {
            var databaseSpaceMetrics = new DatabaseSpaceMetrics();
            var flatResult = command.Result.SelectMany(x => x).Where(x => x.Key == "database_size" || x.Key == "unallocated space");
            var databaseSize = flatResult.FirstOrDefault(x => x.Key == "database_size").Value.Split();
            databaseSpaceMetrics.DatabaseId = command.DatabaseId;
            databaseSpaceMetrics.Space = Convert.ToDouble(flatResult.FirstOrDefault(x => x.Key == "database_size").Value.Split()[0]);
            databaseSpaceMetrics.UnallocatedSpace = Convert.ToDouble(flatResult.FirstOrDefault(x => x.Key == "unallocated space").Value.Split()[0]);
            databaseSpaceMetrics.Unit = "MB";
        }

        private async Task DatabaseBackupMetricCollect(DbWorkerOperationCompleted command)
        {
            var databases = await _databaseService.GetAllAsync(x => x.ServerId == command.SqlServerId);

            foreach (var result in command.Result)
            {
                var databaseBackupMetrics = new DatabaseBackupMetrics();
                var full = result["full DB Backup Status"];
                var transaction = result["transaction DB Backup Status"];
                var differential = result["differential DB Backup Status"];
                var dbName = result["databasE_Name"];

                databaseBackupMetrics.Full = !string.IsNullOrWhiteSpace(full) ? DateTime.Parse(full) : (DateTime?)null;
                databaseBackupMetrics.Transaction = !string.IsNullOrWhiteSpace(transaction) ? DateTime.Parse(transaction) : (DateTime?)null;
                databaseBackupMetrics.Differential = !string.IsNullOrWhiteSpace(differential) ? DateTime.Parse(differential) : (DateTime?)null;
                databaseBackupMetrics.RecoveryModel = result["recoveryModel"];
                databaseBackupMetrics.DatabaseId = databases.FirstOrDefault(x => x.Name == dbName).ServerId;
            }
        }

        private static void USerSessionMetricCollect(DbWorkerOperationCompleted command)
        {
            var flatResults = command.Result.SelectMany(x => x).Where(x => x.Key == "login_name" && x.Value != "");

            foreach (var result in flatResults)
            {
                var userSessionMetrics = new UserSessionMetrics();
                userSessionMetrics.ServerId = command.SqlServerId;
                userSessionMetrics.UserLoginName = result.Value;
            }
        }

        private static void MemoryUsageMetricCollect(DbWorkerOperationCompleted command)
        {
            var memoryUsageMetrics = new MemoryUsageMetrics();

            memoryUsageMetrics.RequestsCount = Convert.ToInt32(command.Result[0]["cntr_value"]);
            memoryUsageMetrics.PageReadsCount = Convert.ToInt32(command.Result[1]["cntr_value"]);
            memoryUsageMetrics.PageLifetime = Convert.ToInt32(command.Result[2]["cntr_value"]);
            memoryUsageMetrics.ServerId = command.SqlServerId;
        }
    }
}
