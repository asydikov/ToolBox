using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.DBWorker.Domain.Models
{
    public class ConnectionModel
    {
        public string Host {   get;  set;}
        public int Port {   get;  set;}
        public string Login {   get;  set;}
        public string Password {   get;  set;}
        public string DatabaseName {   get;  set;}

     
    }
}
