using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.DBWorker.Messages.Commands
{
    [MessageNamespace("dbworker")]
    public class SQLStatementQuery : ICommand
    {
        public Guid Id { get; }
        public string Instruction { get; }
        public string Host { get; }
        public int Port { get; }
        public string DbUserId { get; }
        public string Password { get; }
        public string DatabaseName { get; }

        public Guid SQLServerId { get; }
        public Guid DatabaseId { get; }
        public string Resource { get; }


        [JsonConstructor]
        public SQLStatementQuery(Guid id, string instruction, string host, int port, string dbUserId, string password, string databaseName, Guid sqlServerId, Guid databaseId, string resource)
        {
            Id = id;
            Instruction = instruction;
            Host = host;
            Port = port;
            DbUserId = dbUserId;
            Password = password;
            DatabaseName = databaseName;
            SQLServerId = sqlServerId;
            DatabaseId = databaseId;
            Resource = resource;
        }

        public string GetConncetionString()
        {
            return $"Server={Host}, {Port}; User Id={DbUserId}; Password={Password}; Database={DatabaseName}; MultipleActiveResultSets=true";
        }

    }
}
