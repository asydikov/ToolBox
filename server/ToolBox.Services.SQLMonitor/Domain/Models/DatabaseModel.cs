using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class DatabaseModel : ModelBase
    {
        public Guid ServerId { get; set; }
        public string Name { get; set; }
        public ServerModel Server { get; set; }
    }
}
