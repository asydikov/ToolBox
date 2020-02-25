using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.EF;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class Database : EntityBase
    {
        public Guid ServerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Server Server { get; set; }
    }
}
