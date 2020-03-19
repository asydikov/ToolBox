using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Api.Messages.Commands.SqlMonitor
{
    [MessageNamespace("sqlmonitor")]
    public class ServerConnection : ICommand
    {
        public Guid Id { get; }
        public Guid UserId { get; set; }
        public string Host { get; }
        public int Port { get; }
        public string Login { get; }
        public string Password { get; }
        public string DatabaseName { get; }

        public string Resource { get; }


        [JsonConstructor]
        public ServerConnection(Guid id, Guid userId, string host, int port, string login, string password, string databaseName, string resource)
        {
            Id = id;
            UserId = userId;
            Host = host;
            Port = port;
            Login = login;
            Password = password;
            DatabaseName = databaseName;
            Resource = resource;
        }

    }
}
