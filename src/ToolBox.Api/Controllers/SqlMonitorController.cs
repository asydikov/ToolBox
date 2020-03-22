using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RawRabbit;
using ToolBox.Api.Domain.Models.SqlMonitor;
using ToolBox.Api.Messages.Commands.SqlMonitor;
using ToolBox.Api.RestEaseServices;

namespace ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlMonitorController : BaseController
    {
        private readonly ISqlMonitorService _sqlMonitorService;
        private readonly IBusClient _busClient;
        private readonly ILogger _logger;
        public SqlMonitorController(
              ISqlMonitorService sqlMonitorService,
              IBusClient busClient,
              ILogger<SqlMonitorController> logger)
        {
            _sqlMonitorService = sqlMonitorService;
            _busClient = busClient;
            _logger = logger;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard(Guid userId)
        {
            var result = await _sqlMonitorService.Dashboard(UserId);
            return Ok(result);
        }

        [HttpGet("servers")]
        public async Task<IActionResult> Servers()
        {
            var result = await _sqlMonitorService.Servers(UserId);
            return Ok(result);
        }

        [HttpPost("server-connection-check")]
        public async Task<IActionResult> ServerConnectionCheck(ConnectionModel connectionModel)
        {
            var result = await _sqlMonitorService.ServerConnectionCheck(connectionModel);
            return Ok(new { Name = result });
        }

        [HttpPost("server-add")]
        public async Task<IActionResult> ServerAdd(ServerCreation command)
        {
            command.Id = Guid.NewGuid();
            command.UserId = UserId;
            await _busClient.PublishAsync(command);
            return Accepted();
        }

        [HttpPost("time-consuming-queries")]
        public async Task<IActionResult> TimeConsumingQueries(ServerModel model)
        {
            var result = await _sqlMonitorService.TimeConsumingQueries(model.Id);
            return Ok(result);
        }

        [HttpPost("server-databases")]
        public async Task<IActionResult> ServerDatabases(ServerModel model)
        {
            var result = await _sqlMonitorService.ServerDatabases(model.Id);
            return Ok(result);
            
        }



    }
}