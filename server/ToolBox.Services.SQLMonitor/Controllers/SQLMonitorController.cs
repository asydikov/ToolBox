using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Messages.Commands;
using ToolBox.Services.SQLMonitor.RestEaseServices;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.DBWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlMonitorController : ControllerBase
    {
        private readonly ISqlQueryService _sqlQueryService;
        private readonly IDbWorkerService _dbWorkerService;
        private readonly IScheduleService _scheduleService;
        private readonly IServerService _serverService;

        private readonly IMemoryUsageMetricsService _memoryUsageMetricsService;
        public SqlMonitorController(
            IDbWorkerService dbWorkerService,
            ISqlQueryService sqlQueryService,
            IScheduleService scheduleService,
            IServerService serverService,
            IMemoryUsageMetricsService memoryUsageMetricsService)
        {
            _sqlQueryService = sqlQueryService;
            _dbWorkerService = dbWorkerService;
            _scheduleService = scheduleService;
            _serverService = serverService;
            _memoryUsageMetricsService = memoryUsageMetricsService;
        }

        [HttpPost("server-connection-check")]
        public async Task<IActionResult> ServerConnectionCheck(ConnectionModel connectionModel)
        {
            var result = await _dbWorkerService.ServerConnectionCheck(connectionModel);
            return Ok(result);
        }


        [HttpGet("servers")]
        public async Task<IActionResult> Servers(Guid userId)
        {
            var result = await _serverService.GetAllAsync(x => x.UserId == userId);

            return Ok(result);
        }


        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard(Guid userId)
        {
            var servers = await _serverService.GetAllAsync(x => x.UserId == userId);
            var memoryUsageMetrics = await _memoryUsageMetricsService.GetAllAsync(x => servers.Select(s => s.Id).Contains(x.ServerId));
            var result = new List<SqlServerBadge>();

            foreach (var server in servers)
            {
                var memoryUsageMetric = memoryUsageMetrics.LastOrDefault(x => x.ServerId == server.Id);
                if (memoryUsageMetric == null)
                {
                    continue;
                }
                var serverBadge = new SqlServerBadge
                {
                    ServerId = server.Id,
                    Name = server.Name,
                    PageLifetime = memoryUsageMetric.PageLifetime,
                    PageReadsCounts = memoryUsageMetric.PageReadsCount,
                    RequestCount = memoryUsageMetric.RequestsCount,
                    Description = server.Description,
                    ServerAddress = $"{server.Host}: {server.Port}",
                };

                result.Add(serverBadge);
            }
            return Ok(result);
        }

        [HttpGet("time-consuming-queries")]
        public async Task<IActionResult> TimeConsumingQueries(Guid id)
        {
            Console.WriteLine(id);
            var server = await _serverService.GetAsync(id);
            var query = await _sqlQueryService.GetAsync(x => x.Name == SqlQueryNames.TwentyCPUConsumedQueries);
            var connectionModel = new ConnectionModel
            {
                Host = server.Host,
                Port = server.Port,
                Login = server.Login,
                Password = server.Password,
                QueryString = query.Query
            };
            var dbWorkeResult = await _dbWorkerService.TimeConsumingQueries(connectionModel);

            var result = new List<TimeConsumingQueriesModel>();

            dbWorkeResult.ForEach(x => result.Add(new TimeConsumingQueriesModel
            {
                StatementText = x["Statement Text"],
                AvgCPUTime = Convert.ToInt32(x["Avg CPU Time"])
            }));

            result = result.OrderBy(x => x.AvgCPUTime).ToList();

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet("schedule")]
        public async Task<IActionResult> Get()
        {
            var result = await _scheduleService.GetAllAsync();
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpPost("sql-query")]
        public async Task<IActionResult> Post(SqlQueryModel model)
        {
            var result = await _sqlQueryService.CreateAsync(model);
            return Ok(result);
        }






    }

}