using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Api.Messages.Commands.Identity
{
    [MessageNamespace("identity")]
    public class SignUp : ICommand
    {
        public Guid Id { get; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public SignUp()
        {
           
        }

        [JsonConstructor]
        public SignUp(Guid id, string email, string name, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
        }
    }
}