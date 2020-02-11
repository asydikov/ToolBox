using System;
using ToolBox.Common.Enums;

namespace ToolBox.Common.Events.IdentityService
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public Guid RejectedCommandId { get; set; }
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
        protected AuthenticateUserRejected() { }
        public AuthenticateUserRejected(Guid rejectedCommandId, string email, string reason, string code)
        {
            RejectedCommandId = RejectedCommandId;
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}