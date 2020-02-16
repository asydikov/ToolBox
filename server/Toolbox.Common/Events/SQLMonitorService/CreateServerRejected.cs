using System;

namespace ToolBox.Common.Events.SQLMonitorService
{
    public class CreateServerRejected : IRejectedEvent
    {
         public Guid Id {get;}
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

       

        protected CreateServerRejected() { }
        public CreateServerRejected(Guid id, string email, string reason, string code)
        {
            Id = id;
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}