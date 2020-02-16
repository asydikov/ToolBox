using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using ToolBox.Api.Messages.Commands.Identity;

namespace ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IBusClient _busClient;
        public IdentityController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpGet("me")]
        public IActionResult Get() => Content($"Your id: '{UserId:N}'.");

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            Console.WriteLine($"Api gateway - {command.Email}. Event sharing...");
            await _busClient.PublishAsync(command);
            return Accepted();
        }

        [HttpPut("change-password")]
        public async Task<ActionResult> ChangePassword(ChangePassword command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}