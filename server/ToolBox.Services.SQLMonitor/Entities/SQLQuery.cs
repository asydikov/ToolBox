using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Enums;
using ToolBox.Services.SQLMonitor.EF;

namespace ToolBox.Services.SQLMonitor.Entities
{
    public class SqlQuery : EntityBase
    {
        public SqlQueryNames Name { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public bool IsStoredProcedure { get; set; }
        public virtual ICollection<ScheduleSqlQuery> ScheduleSqlQueries { get; set; }
    }
}
