using System;
using Newtonsoft.Json;
using ToolBox.Common.Commands;

namespace ToolBox.Services.Identity.Messages.Commands
{
    public class ChangePassword : ICommand
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePassword()
        {

        }

        [JsonConstructor]
        public ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            UserId = userId;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }

    }
}