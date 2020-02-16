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

       /* [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            // command.BindId(c => c.Id);
            await _identityService.SignUpAsync(command.Id, command.Email, command.Name, command.Password);
            return Accepted();
        }*/

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignIn command)
            => Ok(await _identityService.SignInAsync(command.Email, command.Password));

       /* [HttpPut("change-password")]
        public async Task<ActionResult> ChangePassword(ChangePassword command)
        {
            // await _identityService.ChangePasswordAsync(command.Bind(c => c.UserId, UserId).UserId,
            await _identityService.ChangePasswordAsync(command.UserId, command.CurrentPassword, command.NewPassword);
            return Accepted();
        }*/
    }
}   