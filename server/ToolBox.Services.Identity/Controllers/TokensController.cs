using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolBox.Common.Auth;
using ToolBox.Common.Commands;
using ToolBox.Services.Identity.Messages.Commands;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokensController : BaseController
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public TokensController(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("access-tokens/refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshAccessToken(RefreshAccessToken accessToken)
            => Ok(await _refreshTokenService.CreateAccessTokenAsync(accessToken.Token));

        // => Ok(await _refreshTokenService.CreateAccessTokenAsync(command.Bind(c => c.Token, refreshToken).Token));
    }
}