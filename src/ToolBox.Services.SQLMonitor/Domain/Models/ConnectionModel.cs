using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class ConnectionModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string QueryString { get; set; }

        public ConnectionModel()
        {

        }

    }
}
