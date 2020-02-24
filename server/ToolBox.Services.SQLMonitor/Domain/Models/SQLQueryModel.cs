using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class SqlQueryModel : ModelBase
    {
        public string Name { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public bool IsStoredProcedure { get; set; }
    }
}
