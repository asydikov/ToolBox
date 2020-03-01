using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using ToolBox.Services.DBWorker.Domain.Models;
using ToolBox.Services.DBWorker.Services;

namespace ToolBox.Services.DBWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbWorkerController : ControllerBase
    {
        private readonly ISQLService _sqlService;

        public DbWorkerController(ISQLService sqlService)
        {
            _sqlService = sqlService;
        }

        [HttpPost("server-connection-check")]
        public async Task<IActionResult> ServerConnectionCheck(ConnectionModel connectionModel)
        {
            var result = await _sqlService.IsSqlConnected(connectionModel);

            return Ok(result);
        }
    }
}