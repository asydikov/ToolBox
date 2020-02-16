using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Api.Messages.Commands.Identity
{
    [MessageNamespace("identity")]
    public class ChangePassword : ICommand
    {
        public Guid Id { get; }
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePassword()
        {

        }

        [JsonConstructor]
        public ChangePassword(Guid? id, Guid userId, string currentPassword, string newPassword)
        {
            Id = id ?? Guid.NewGuid();
            UserId = userId;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

    }
}
