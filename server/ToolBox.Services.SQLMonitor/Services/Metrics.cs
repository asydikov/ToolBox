using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class Metrics : IMetrics
    {
        private readonly ILogger _logger;

        public Metrics(ILogger<Metrics> logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.LogInformation("Timed Background Service is working.");
        }
    }
}
