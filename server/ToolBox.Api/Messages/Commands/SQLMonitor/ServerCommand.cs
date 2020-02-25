﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbox.Common.Messages;
using ToolBox.Common.Commands;

namespace ToolBox.Api.Messages.Commands.SQLMonitor
{
    [MessageNamespace("sqlmonitor")]
    public class ServerCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Guid> DatabaseIdList { get; set; }


        [JsonConstructor]
        public ServerCommand(Guid id, Guid userId, string name, string host, int port, string login, string password, List<Guid> databaseIdList)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Host = host;
            Port = port;
            Login = login;
            Password = password;
            DatabaseIdList = databaseIdList;
        }
    }
}