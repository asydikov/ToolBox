using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Messages.Commands
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