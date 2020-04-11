using System;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ToolBox.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        protected Guid UserId
           => string.IsNullOrWhiteSpace(User?.Identity?.Name) ?
               Guid.Empty :
               Guid.Parse(User.Identity.Name);

    }
}