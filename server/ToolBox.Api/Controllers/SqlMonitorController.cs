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
using ToolBox.Api.Services;

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


        [HttpGet("server-connection-check")]
        public async Task<IActionResult> ServerConnectionCheck(ConnectionModel connectionModel)
        {
            var result = await _sqlMonitorService.ServerConnectionCheck(connectionModel);

            return Ok(result);
        }


        [HttpPost("server")]
        public async Task<IActionResult> ServerAdd(ServerCommand command)
        {
            command.Id = Guid.NewGuid();
            command.UserId = UserId;
            await _busClient.PublishAsync(command);
            return Accepted();
        }




    }
}