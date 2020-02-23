using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class SQLQuery : EntityBase
    {
        public string Name { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public bool IsStoredProcedure { get; set; }
    }
}
