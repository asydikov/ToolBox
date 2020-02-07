using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class UserCreatedEvent : IEvent
    {
        public string Email { get; }
        public string Name { get; }

        //Just for serialization operations
        protected UserCreatedEvent() { }

        public UserCreatedEvent(Guid id, string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}