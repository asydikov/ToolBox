using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class SignedUp : IEvent
    {
        public Guid Id { get; }
        public string Email { get; }

        //Just for serialization operations
        protected SignedUp() { }

        public SignedUp(Guid id, string email)
        {
            Id = id;
            Email = email; ;
        }

    }
}