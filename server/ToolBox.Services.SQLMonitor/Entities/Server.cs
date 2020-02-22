using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class Server : EntityBase
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Database> Databases { get; set; }
    }
}
