using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Services.Identity.Messages.Commands;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignIn command)
        {
            Console.WriteLine($"Identity controller - {command.Email}");
            return Ok(await _identityService.SignInAsync(command.Email, command.Password));
        }
    }
}   