using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string Name { get; }

        //Just for serialization operations
        protected UserCreated() { }

        public UserCreated(Guid id, string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}