using System;
using Newtonsoft.Json;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    public class SignUpRejected : IRejectedEvent
    {
        public Guid UserId { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public SignUpRejected(Guid userId, string reason, string code)
        {
            UserId = userId;
            Reason = reason;
            Code = code;
        }
    }
}