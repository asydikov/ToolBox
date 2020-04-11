using System;

namespace ToolBox.Common.Events
{
    public interface IEvent
    {
        public Guid Id { get; }
    }
}