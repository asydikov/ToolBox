using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RawRabbit;
using ToolBox.Api.Domain.Models.Identity;
using ToolBox.Api.Messages.Commands.Identity;
using ToolBox.Api.Services.Identity;

namespace ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public IdentityController(IIdentityService identityService, 
            IBusClient busClient,
             ILogger<IdentityController> logger)
        {
            _identityService = identityService;
            _busClient = busClient;
            _logger = logger;
        }

        [HttpGet("me")]
        public IActionResult Get() => Content($"Your id: '{UserId:N}'.");

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            Console.WriteLine($"Api gateway signup- {model.Email}");
           return Ok(await _identityService.SignUp(model));
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            Console.WriteLine($"Api controller - {model.Email}");
            var result = await _identityService.SignIn(model);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("change-password")]
        public async Task<ActionResult> ChangePassword(ChangePassword command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}