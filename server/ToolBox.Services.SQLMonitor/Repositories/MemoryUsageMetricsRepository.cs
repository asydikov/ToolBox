﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.EF;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Repositories
{
    public class MemoryUsageMetricsRepository : RepositoryBase<MemoryUsageMetrics>, IMemoryUsageMetricsRepository
    {
        public MemoryUsageMetricsRepository(SqlMonitorDbContext context) : base(context) { }
    }
}
