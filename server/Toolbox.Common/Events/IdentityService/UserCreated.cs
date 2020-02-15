using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class UserCreated : IEvent
    {
        public Guid EventId { get; set; }
        public string Email { get; }
        public string Name { get; }

        //Just for serialization operations
        protected UserCreated() { }

        public UserCreated(Guid eventId, string email)
        {
            EventId = eventId;
            Email = email;
        }
    }
}