using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.RestEaseServices;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.SQLMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlMonitorController : ControllerBase
    {
        private readonly ISqlQueryService _sqlQueryService;
        private readonly IDbWorkerService _dbWorkerService;
        private readonly IServerService _serverService;
        private readonly IDatabaseService _databaseService;
        private readonly IDatabaseBackupMetricsService _databaseBackupMetricsService;
        private readonly IDatabaseSpaceMetricsService _databaseSpaceMetricsService;
        private readonly IDataProtector _protector;

        private readonly IMemoryUsageMetricsService _memoryUsageMetricsService;
        public SqlMonitorController(
            IDbWorkerService dbWorkerService,
            ISqlQueryService sqlQueryService,
            IServerService serverService,
            IMemoryUsageMetricsService memoryUsageMetricsService,
            IDatabaseService databaseService,
            IDatabaseBackupMetricsService databaseBackupMetricsService,
            IDatabaseSpaceMetricsService databaseSpaceMetricsService,
            IDataProtectionProvider dataProtector)
        {
            _sqlQueryService = sqlQueryService;
            _dbWorkerService = dbWorkerService;
            _serverService = serverService;
            _memoryUsageMetricsService = memoryUsageMetricsService;
            _databaseService = databaseService;
            _databaseBackupMetricsService = databaseBackupMetricsService;
            _databaseSpaceMetricsService = databaseSpaceMetricsService;
            _protector = dataProtector.CreateProtector("sql-server-pass-protector");
        }
       
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard(Guid userId)
        {
            var servers = await _serverService.GetAllAsync(x => x.UserId == userId);
            var memoryUsageMetrics = await _memoryUsageMetricsService.GetAllAsync(x => servers.Select(s => s.Id).Contains(x.ServerId));
            var result = new List<SqlServerBadgeModel>();

            foreach (var server in servers.OrderBy(x => x.CreatedDate))
            {
                var memoryUsageMetric = memoryUsageMetrics.LastOrDefault(x => x.ServerId == server.Id);

                var serverBadge = new SqlServerBadgeModel
                {
                    ServerId = server.Id,
                    Name = server.Name,
                    PageLifetime = memoryUsageMetric?.PageLifetime ?? 0,
                    PageReadsCount = memoryUsageMetric?.PageReadsCount ?? 0,
                    RequestCount = memoryUsageMetric?.RequestsCount ?? 0,
                    Description = server.Description,
                    ServerAddress = $"{server.Host}: {server.Port}",
                    ConnectedUsers = 0,
                    IsAlive = true
                };

                result.Add(serverBadge);
            }
            return Ok(result);
        }

        [HttpGet("servers")]
        public async Task<IActionResult> Servers(Guid userId)
        {
            var result = await _serverService.GetAllAsync(x => x.UserId == userId);

            return Ok(result);
        }

        [HttpPost("server-connection-check")]
        public async Task<IActionResult> ServerConnectionCheck(ConnectionModel connectionModel)
        {
            var result = await _dbWorkerService.ServerConnectionCheck(connectionModel);
            return Ok(result);
        }

        [HttpGet("server-databases")]
        public async Task<IActionResult> ServerDatabases(Guid id)
        {
            var result = new List<DatabaseBadgeModel>();
            var databases = await _databaseService.GetAllAsync(x => x.ServerId == id);

            foreach (var database in databases)
            {
                var dbBackups = await _databaseBackupMetricsService.GetAllAsync(x => x.DatabaseId == database.Id);
                var dbBackup = dbBackups.OrderBy(x => x.CreatedDate).LastOrDefault();
                var dbMetricsAll = await _databaseSpaceMetricsService.GetAllAsync(x => x.DatabaseId == database.Id);
                var dbMetrics = dbMetricsAll.OrderBy(x => x.CreatedDate).LastOrDefault();

                result.Add(
                    new DatabaseBadgeModel
                    {
                        Id = database.Id,
                        Name = database.Name,
                        DifferentialBackupTime = dbBackup.Differential,
                        FullBackupTime = dbBackup.Full,
                        TransactionLogBackupTime = dbBackup.Transaction,
                        RecoveryModel = dbBackup.RecoveryModel,
                        Space = dbMetrics.Space,
                        UnallocatedSpace = dbMetrics.UnallocatedSpace,
                        Unit = dbMetrics.Unit
                    });

            }
            return Ok(result);
        }

        [HttpGet("time-consuming-queries")]
        public async Task<IActionResult> TimeConsumingQueries(Guid id)
        {
            var server = await _serverService.GetAsync(id);
            var query = await _sqlQueryService.GetAsync(x => x.Name == SqlQueryNames.TwentyCPUConsumedQueries);


            var connectionModel = new ConnectionModel
            {
                Host = server.Host,
                Port = server.Port,
                Login = server.Login,
                Password = _protector.Unprotect(server.Password),
                QueryString = query.Query
            };
            var dbWorkeResult = await _dbWorkerService.TimeConsumingQueries(connectionModel);

            var result = new List<TimeConsumingQueriesModel>();

            dbWorkeResult.ForEach(x => result.Add(new TimeConsumingQueriesModel
            {
                StatementText = x["Statement Text"],
                AvgCPUTime = Convert.ToDouble(Convert.ToDouble(x["Avg CPU Time"]) / 100000),
                Selector = x["Statement Text"].Split().FirstOrDefault()?.ToUpper()
            }));

            result = result.OrderByDescending(x => x.AvgCPUTime).ToList();

            return Ok(result);
        }
    }

}