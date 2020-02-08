using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using ToolBox.Common.Commands.IdentityService;

namespace ToolBox.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IBusClient _busClient;
        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }


        [HttpGet("")]
        public IActionResult Get()
        {
            _busClient.PublishAsync(new CreateUser());
            return Content("Thank you for creating me, with love - ToolBox");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _busClient.PublishAsync(command);
            return Content("Hello world");
        }
    }
}