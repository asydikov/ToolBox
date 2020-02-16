using System;
using Newtonsoft.Json;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    [MessageNamespace("identity")]
    public class SignUpRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public SignUpRejected(Guid id, Guid userId, string reason, string code)
        {
            Id = id;
            UserId = userId;
            Reason = reason;
            Code = code;
        }
    }
}