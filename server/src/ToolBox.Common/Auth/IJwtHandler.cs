using System;
using System.Collections.Generic;

namespace ToolBox.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken CreateToken(string userId, string role = null, IDictionary<string, string> claims = null);
    }
}