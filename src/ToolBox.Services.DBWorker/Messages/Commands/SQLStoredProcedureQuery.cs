﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.DBWorker.Messages.Commands
{
    [MessageNamespace("dbworker")]
    public class SqlStoredProcedureQuery : ICommand
    {

        public Guid Id { get; }
        public Guid UserId { get; set; }
        public string StoredProcedureName { get; }
        public Dictionary<string, string> Parameters { get; }
        public string Host { get; }
        public int Port { get; }
        public string Login { get; }
        public string Password { get; }
        public string DatabaseName { get; }
        public int SqlQueryName { get; set; }
        public Guid SqlServerId { get; }
        public Guid DatabaseId { get; }
        public string Resource { get; }

        [JsonConstructor]
        public SqlStoredProcedureQuery(Guid id,
            Guid userId, 
            string storedProcedureName,
            Dictionary<string, string> parameters, 
            string host, 
            int port, 
            string login, 
            string password, 
            string databaseName,
             int sqlQueryName,
            Guid sqlServerId,
            Guid databaseId,
            string resource)
        {
            Id = id;
            UserId = userId;
            StoredProcedureName = storedProcedureName;
            Parameters = parameters;
            Host = host;
            Port = port;
            Login = login;
            Password = password;
            DatabaseName = databaseName;
            SqlQueryName = sqlQueryName;
            SqlServerId = sqlServerId;
            DatabaseId = databaseId;
            Resource = resource;
        }
    }
}
