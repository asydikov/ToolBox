using System;

namespace ToolBox.Common.Commands.IdentityService
{
    public class CreateUser : ICommand
    {
        public Guid CommandId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public CreateUser()
        {
            CommandId = Guid.NewGuid();
        }
    }
}