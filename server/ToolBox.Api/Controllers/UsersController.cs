using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using ToolBox.Common.Commands.IdentityService;

namespace ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IBusClient _busClient;
        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }     

        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Thank you for creating me, with love - ToolBox");
        }

        // [HttpGet("")]
        // public IActionResult Get()
        // {
        //     _busClient.PublishAsync(new CreateUser());
        //     return Content("Thank you for creating me, with love - ToolBox");
        // }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            Console.WriteLine($"User controller {command.Name}{command.Email}{command.Password}");
            await _busClient.PublishAsync(command);
            return Content("Hello world");
        }
    }
}