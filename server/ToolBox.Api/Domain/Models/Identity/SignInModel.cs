using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Api.Domain.Models.Identity
{
    public class SignInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
