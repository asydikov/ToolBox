using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Domain.Models
{
    public class SignUpModel
    {
        public Guid Id { get; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public SignUpModel()
        {

        }

        public SignUpModel(Guid? id, string email, string name, string password)
        {
            Id = id ?? Guid.NewGuid();
            Email = email;
            Name = name;
            Password = password;
        }
    }
}