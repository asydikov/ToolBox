using Newtonsoft.Json;
using System;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Messages.Commands
{
    [MessageNamespace("identity")]
    public class SignIn : ICommand
    {
        public Guid Id { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SignIn()
        {

        }
        [JsonConstructor]
        public SignIn(Guid? id, string email, string password)
        {
            Id = id ?? Guid.NewGuid();
            Email = email;
            Password = password;
        }
    }
}