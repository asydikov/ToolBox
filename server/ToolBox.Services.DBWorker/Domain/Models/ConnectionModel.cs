using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.DBWorker.Domain.Models
{
    public class ConnectionModel
    {
        public ConnectionModel(string host, int port, string login, string password, string databaseName)
        {
            Host = host;
            Port = port;
            Login = login;
            Password = password;
            DatabaseName = databaseName;
        }

        public ConnectionModel() { }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }


    }
}
