using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Api.Domain.Models.Identity
{
    public class SignUpModel
    {
        public Guid Id { get; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}