using System;

namespace ToolBox.Common.Events.SQLMonitorService
{
    public class ServerCreated : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Name { get; }
        // public ServerType Type { get; }
        public string Address { get; }
        public int Port { get; }
        public string Login { get; }
        public string Password { get; }
        protected ServerCreated() { }
        public ServerCreated(Guid id, string name, string address, int port, string login, string password)
        {
            Id = id;
            Name = name;
            // Type = type;
            Address = address;
            Port = port;
            Login = login;
            Password = password;
        }
    }
}