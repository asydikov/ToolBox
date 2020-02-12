using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class CreateUserRejected : IRejectedEvent
    {
        public Guid RejectedCommandId { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateUserRejected() { }
        public CreateUserRejected(Guid rejectedCommandId, string code, string reason)
        {
            RejectedCommandId = RejectedCommandId;
            Code = code;
            Reason = reason;
        }
    }
}