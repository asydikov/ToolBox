using System;

namespace ToolBox.Services.Notification.Framework
{
    public static class Extensions
    {
        public static string ToUserGroup(this Guid userId)
            => $"users:{userId}";
    }
}
