using System;
using ToolBox.Common.Enums;

namespace ToolBox.Common.Events.IdentityService
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public RejectionCode Code { get; }
        protected CreateUserRejected() { }
        public CreateUserRejected(string email, string reason, RejectionCode code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}