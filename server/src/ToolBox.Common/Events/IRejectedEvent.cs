using System;
using ToolBox.Common.Enums;

namespace ToolBox.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        Guid RejectedCommandId { get; set; }
        string Reason { get; }
        string Code { get; }
    }
}