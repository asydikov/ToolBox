using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class UserAuthenticated : IEvent
    {
        public string Email { get; set; }
        protected UserAuthenticated() { }
        public UserAuthenticated(Guid id, string email)
        {
            Email = email;
        }
    }
}