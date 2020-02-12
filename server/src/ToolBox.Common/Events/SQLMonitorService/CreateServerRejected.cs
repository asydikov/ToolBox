using System;

namespace ToolBox.Common.Events.SQLMonitorService
{
    public class CreateServerRejected : IRejectedEvent
    {
        public Guid RejectedCommandId { get; set; }
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
        protected CreateServerRejected() { }
        public CreateServerRejected(Guid rejectedCommandId, string email, string reason, string code)
        {
            RejectedCommandId = RejectedCommandId;
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}