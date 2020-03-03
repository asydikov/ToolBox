using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class DatabaseSpaceMetric
    {
        public Guid DatabaseId { get; set; }
        public Database Database { get; set; }
        public double Space { get; set; }
        public double UnallocatedSpace { get; set; }
        public string Unit { get; set; }
    }

    public class DatabaseBackupMetric
    {
        public Guid DatabaseId { get; set; }
        public Database Database { get; set; }
        public DateTime? Full { get; set; }
        public DateTime? Differential { get; set; }
        public DateTime? Transaction { get; set; }
        public string RecoveryModel { get; set; }
    }

    public class UserSessionMetric
    {
        public Guid ServerId { get; set; }
        public Server Server { get; set; }
        public string UserLoginName { get; set; }
    }

    public class MemoryUsageMetric
    {
        public Guid ServerId { get; set; }
        public Server Server { get; set; }
        public int PageLifetime { get; set; }
        public int RequestsCount { get; set; }
        public int PageReadsCount { get; set; }
    }

    public class MetricsProcessingService : IMetricsProcessingService
    {
        private readonly IServerService _serverService;
        private readonly IDatabaseService _databaseService;
        public MetricsProcessingService(IServerService serverService, IDatabaseService databaseService)
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
            var databaseSpaceMetric = new DatabaseSpaceMetric();
            var flatResult = command.Result.SelectMany(x => x).Where(x => x.Key == "database_size" || x.Key == "unallocated space");
            var databaseSize = flatResult.FirstOrDefault(x => x.Key == "database_size").Value.Split();
            databaseSpaceMetric.DatabaseId = command.DatabaseId;
            databaseSpaceMetric.Space = Convert.ToDouble(flatResult.FirstOrDefault(x => x.Key == "database_size").Value.Split()[0]);
            databaseSpaceMetric.UnallocatedSpace = Convert.ToDouble(flatResult.FirstOrDefault(x => x.Key == "unallocated space").Value.Split()[0]);
            databaseSpaceMetric.Unit = "MB";
        }

        private async Task DatabaseBackupMetricCollect(DbWorkerOperationCompleted command)
        {
            var databases = await _databaseService.GetAllAsync(x => x.ServerId == command.SQLServerId);

            foreach (var result in command.Result)
            {
                var databaseBackupMetric = new DatabaseBackupMetric();
                var full = result["full DB Backup Status"];
                var transaction = result["transaction DB Backup Status"];
                var differential = result["differential DB Backup Status"];
                var dbName = result["databasE_Name"];

                databaseBackupMetric.Full = !string.IsNullOrWhiteSpace(full) ? DateTime.Parse(full) : (DateTime?)null;
                databaseBackupMetric.Transaction = !string.IsNullOrWhiteSpace(transaction) ? DateTime.Parse(transaction) : (DateTime?)null;
                databaseBackupMetric.Differential = !string.IsNullOrWhiteSpace(differential) ? DateTime.Parse(differential) : (DateTime?)null;
                databaseBackupMetric.RecoveryModel = result["recoveryModel"];
                databaseBackupMetric.DatabaseId = databases.FirstOrDefault(x => x.Name == dbName).ServerId;
            }
        }

        private static void USerSessionMetricCollect(DbWorkerOperationCompleted command)
        {
            var flatResults = command.Result.SelectMany(x => x).Where(x => x.Key == "login_name" && x.Value != "");

            foreach (var result in flatResults)
            {
                var userSessionMetric = new UserSessionMetric();
                userSessionMetric.ServerId = command.SQLServerId;
                userSessionMetric.UserLoginName = result.Value;
            }
        }

        private static void MemoryUsageMetricCollect(DbWorkerOperationCompleted command)
        {
            var memoryUsageMetric = new MemoryUsageMetric();

            memoryUsageMetric.RequestsCount = Convert.ToInt32(command.Result[0]["cntr_value"]);
            memoryUsageMetric.PageReadsCount = Convert.ToInt32(command.Result[1]["cntr_value"]);
            memoryUsageMetric.PageLifetime = Convert.ToInt32(command.Result[2]["cntr_value"]);
            memoryUsageMetric.ServerId = command.SQLServerId;
        }
    }
}
