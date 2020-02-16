using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    [MessageNamespace("identity")]
    public class PasswordChanged : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }

        [JsonConstructor]
        public PasswordChanged(Guid id, Guid userId)
        {
            Id = Id;
            UserId = userId;
        }
    }
}