using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    [MessageNamespace("identity")]
    public class SignedUp : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Email { get; }

        [JsonConstructor]
        public SignedUp(Guid id, Guid userId, string email)
        {
            Id = id;
            UserId = userId;
            Email = email;
        }
    }
}