using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Messages.Commands;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.DBWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlMonitorController : ControllerBase
    {
        private readonly IBusClient _busClient;
        private readonly ISqlQueryService _sqlQueryService;
        private readonly IServerService _serverService;
        public SqlMonitorController(IBusClient busClient,
            ISqlQueryService sqlQueryService,
            IServerService serverService)
        {
            _busClient = busClient;
            _sqlQueryService = sqlQueryService;
            _serverService = serverService;

        }

        [AllowAnonymous]
        [HttpPost("sql-query")]
        public async Task<IActionResult> Post(SqlQueryModel model)
        {
            var result = await _sqlQueryService.CreateAsync(model);
            return Ok(result);
        }

      

        [AllowAnonymous]
        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var d = new Dictionary<string, string>();
            d.Add("@oneresultset", "1");
            await _busClient.PublishAsync(new SqlStoredProcedureQuery(
                  Guid.NewGuid(),
                  "sp_spaceused",
                  d,
                  "localhost",
                  1455,
                  "sa",
                  "Pass_w0rd12",
                  "Identity",
                  Guid.NewGuid(),
                  Guid.NewGuid(),
                  "sqlmonitor-service"));


            return Ok();
        }




    }

}