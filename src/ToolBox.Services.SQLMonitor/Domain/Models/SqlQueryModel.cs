using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Enums;

namespace ToolBox.Services.SQLMonitor.Domain.Models
{
    public class SqlQueryModel : ModelBase
    {
        public SqlQueryNames Name { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public bool IsStoredProcedure { get; set; }
    }
}
