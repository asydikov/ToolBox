using Newtonsoft.Json;
using System;
using Toolbox.Common.Messages;
using ToolBox.Common.Events;

namespace ToolBox.Services.Identity.Messages.Events
{
    [MessageNamespace("identity")]
    public class SignInRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public SignInRejected(Guid id, string email, string reason, string code)
        {
            Id = id;
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}