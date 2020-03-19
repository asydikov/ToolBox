using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Services.Identity.Domain.Models;
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
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpModel model)
            => Ok(await _identityService.SignUpAsync(model.Email, model.Name, model.Password));

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel model)
            => Ok(await _identityService.SignInAsync(model.Email, model.Password));


    }
}