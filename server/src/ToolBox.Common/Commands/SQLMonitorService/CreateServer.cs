using System;
using ToolBox.Common.Enums;

namespace ToolBox.Common.Commands.SQLMonitorService
{
    public class CreateServer : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
        public ServerType Type { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}