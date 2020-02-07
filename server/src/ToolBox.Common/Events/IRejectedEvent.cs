using ToolBox.Common.Enums;

namespace ToolBox.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        RejectionCode Code { get; }
    }
}