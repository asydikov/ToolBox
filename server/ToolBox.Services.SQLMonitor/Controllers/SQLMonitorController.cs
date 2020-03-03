using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
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
        public SqlMonitorController(
            IDbWorkerService dbWorkerService,
            ISqlQueryService sqlQueryService,
            IScheduleService scheduleService,
            IServerService serverService)
        {
            _sqlQueryService = sqlQueryService;
            _dbWorkerService = dbWorkerService;
            _scheduleService = scheduleService;
            _serverService = serverService;
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