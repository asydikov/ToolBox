using Microsoft.AspNetCore.Mvc;

namespace ToolBox.Api.Controllers
{

    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Thank you for creating me, with love - ToolBox");
    }
}