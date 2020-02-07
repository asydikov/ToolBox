using ToolBox.Common.Enums;

namespace ToolBox.Common.Events.SQLMonitorService
{
    public class CreateServerRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public RejectionCode Code { get; }
        protected CreateServerRejected() { }
        public CreateServerRejected(string email, string reason, RejectionCode code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}