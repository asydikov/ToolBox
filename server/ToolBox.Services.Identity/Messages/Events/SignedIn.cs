using System;
using Newtonsoft.Json;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    public class SignedIn : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public SignedIn(Guid userId)
        {
            UserId = userId;
        }
    }
}