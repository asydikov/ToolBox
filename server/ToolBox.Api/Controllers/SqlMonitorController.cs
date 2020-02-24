using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RawRabbit;
using ToolBox.Api.Messages.Commands.SQLMonitor;
using ToolBox.Api.Services;

namespace ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlMonitorController : BaseController
    {
        private readonly IBusClient _busClient;
        private readonly ISqlMonitorService _identityService;
        private readonly ILogger _logger;
        public SqlMonitorController(ISqlMonitorService identityService,
            IBusClient busClient,
             ILogger<SqlMonitorController> logger)
        {
            _identityService = identityService;
            _busClient = busClient;
            _logger = logger;
        }


        [HttpPost()]
        public async Task<IActionResult> Post(ServerCommand command)
        {
            command.Id = Guid.NewGuid();
            command.UserId = UserId;
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}