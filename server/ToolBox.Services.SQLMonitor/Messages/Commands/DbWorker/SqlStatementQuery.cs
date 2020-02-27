﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Services.SQLMonitor.Messages.Commands.DbWorker
{
    [MessageNamespace("dbworker")]
    public class SqlStatementQuery : ICommand
    {
        public Guid Id { get; }
        public Guid UserId { get; set; }
        public string Instruction { get; }
        public string Host { get; }
        public int Port { get; }
        public string Login { get; }
        public string Password { get; }
        public string DatabaseName { get; }

        public Guid SQLServerId { get; }
        public Guid DatabaseId { get; }
        public string Resource { get; }


        [JsonConstructor]
        public SqlStatementQuery(Guid id, Guid userId, string instruction, string host, int port, string login, string password, string databaseName, Guid sqlServerId, Guid databaseId, string resource)
        {
            Id = id;
            UserId = userId;
            Instruction = instruction;
            Host = host;
            Port = port;
            Login = login;
            Password = password;
            DatabaseName = databaseName;
            SQLServerId = sqlServerId;
            DatabaseId = databaseId;
            Resource = resource;
        }

    }
}
