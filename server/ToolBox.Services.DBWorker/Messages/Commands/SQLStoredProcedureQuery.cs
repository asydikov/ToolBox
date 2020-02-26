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
    public class SqlStoredProcedureQuery : ICommand
    {

        public Guid Id { get; }
        public string StoredProcedureName { get; }
        public Dictionary<string, string> Parameters { get; }
        public string Host { get; }
        public int Port { get; }
        public string Login { get; }
        public string Password { get; }
        public string DatabaseName { get; }
        public Guid SQLServerId { get; }
        public Guid DatabaseId { get; }
        public string Resource { get; }

        [JsonConstructor]
        public SqlStoredProcedureQuery(Guid id, string storedProcedureName, Dictionary<string, string> parameters, string host, int port, string login, string password, string databaseName, Guid sqlServerId, Guid databaseId, string resource)
        {
            Id = id;
            StoredProcedureName = storedProcedureName;
            Parameters = parameters;
            Host = host;
            Port = port;
            Login = login;
            Password = password;
            DatabaseName = databaseName;
            SQLServerId = sqlServerId;
            DatabaseId = databaseId;
            Resource = resource;
        }

        public string GetConncetionString()
        {
            return $"Server={Host}, {Port}; User Id={Login}; Password={Password}; Database={DatabaseName}; MultipleActiveResultSets=true";
        }
    }
}
