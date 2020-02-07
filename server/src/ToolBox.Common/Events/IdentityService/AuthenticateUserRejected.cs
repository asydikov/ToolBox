using ToolBox.Common.Enums;

namespace ToolBox.Common.Events.IdentityService
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public RejectionCode Code { get; }
        protected AuthenticateUserRejected() { }
        public AuthenticateUserRejected(string email, string reason, RejectionCode code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}