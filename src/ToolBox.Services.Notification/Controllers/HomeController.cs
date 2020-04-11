using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToolBox.Services.Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       
            [HttpGet]
            public IActionResult Get() => Ok("Toolbox SignalR Service");



        [HttpGet("test")]
        public ActionResult Test()
        {
          /*  var fileContent = System.IO.File.ReadAllText("Content/index.html");
            StreamReader reader = new StreamReader("");*/

            var fileBytes = System.IO.File.ReadAllBytes("Content/index.html");

            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
    }
}