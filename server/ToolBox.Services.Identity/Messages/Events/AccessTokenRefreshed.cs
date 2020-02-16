using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    [MessageNamespace("identity")]
    public class AccessTokenRefreshed : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }

        [JsonConstructor]
        public AccessTokenRefreshed(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}