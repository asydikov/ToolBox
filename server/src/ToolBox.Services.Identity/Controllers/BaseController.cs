using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToolBox.Services.Identity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        protected bool IsAdmin
            => User.IsInRole("admin");

        protected Guid UserId
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ?
                Guid.Empty :
                Guid.Parse(User.Identity.Name);
    }
}