using Microsoft.AspNetCore.Mvc;

namespace ToolBox.Api.Controllers
{

    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Thank you for creating me, with love - ToolBox");
    }
}