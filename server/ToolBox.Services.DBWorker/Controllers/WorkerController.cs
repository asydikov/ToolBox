using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ToolBox.Services.DBWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {

        public WorkerController()
        {

        }

        [AllowAnonymous]
        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var conncectionString = "Server=localhost, 1455; User Id=sa; Password=Pass_w0rd12; Database=master; MultipleActiveResultSets=true";
            var parameters = new Dictionary<string, string>();
            parameters.Add("@oneresultset", "1");

            var query = @"select * from [Identity].[dbo].[Users]";

            ////List<Dictionary<string, string>> res = MakeRSQLServerequest(conncectionString, query);
            //List<Dictionary<string, string>> res = MakeRSQLServerequest(conncectionString, "sp_spaceused", true, parameters);

            //return Ok(res);

            return Ok();
        }




    }

}