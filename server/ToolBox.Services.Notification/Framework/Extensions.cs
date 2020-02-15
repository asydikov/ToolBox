using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.Notification.Framework
{
    public static class Extensions
    {
        public static string ToUserGroup(this Guid userId)
            => $"users:{userId}";
    }
}
