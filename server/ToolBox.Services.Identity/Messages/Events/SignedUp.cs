using System;
using Newtonsoft.Json;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    public class SignedUp : IEvent
    {
        public Guid UserId { get; }
        public string Email { get; }

        [JsonConstructor]
        public SignedUp(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}