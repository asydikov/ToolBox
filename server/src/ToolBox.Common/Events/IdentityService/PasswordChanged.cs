using System;

namespace ToolBox.Common.Events.IdentityService
{
    public class PasswordChanged : IEvent
    {
        public Guid UserId { get; }

        protected PasswordChanged() { }

        public PasswordChanged(Guid userId)
        {
            UserId = userId;
        }
    }
}