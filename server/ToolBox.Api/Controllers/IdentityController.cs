﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RawRabbit;
using ToolBox.Api.Domain.Models.Identity;
using ToolBox.Api.Messages.Commands.Identity;
using ToolBox.Api.RestEaseServices;

namespace ToolBox.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IBusClient _busClient;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;
        public IdentityController(
              IIdentityService identityService,
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
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            Console.WriteLine($"Api gateway signup- {signUpModel.Email}");
            return Ok(await _identityService.SignUp(signUpModel));
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            Console.WriteLine($"Api controller - {signInModel.Email}");
            var result = await _identityService.SignIn(signInModel);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("password-change")]
        public async Task<ActionResult> ChangePassword(ChangePassword command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }

        [AllowAnonymous]
        [HttpPost("token-refresh")]
        public async Task<IActionResult> RefreshAccessToken(TokenModel model)
            => Ok(await _identityService.RefreshToken(model));
    }
}