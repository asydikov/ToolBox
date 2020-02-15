using System;

namespace ToolBox.Common.Commands.IdentityService
{

    public class AuthenticateUser : ICommand
    {
        public Guid CommandId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthenticateUser()
        {
            CommandId = Guid.NewGuid();
        }
    }
}