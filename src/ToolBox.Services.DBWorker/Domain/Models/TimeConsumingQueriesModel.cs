using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.DBWorker.Domain.Models
{
    public class TimeConsumingQueriesModel
    {
        public string ConnectionString { get; set; }
        public string QueryString { get; set; }

        public string QueryHash { get; set; }
        public int AvgCPUTime { get; set; }
        public string StatementText { get; set; }
    }
}
