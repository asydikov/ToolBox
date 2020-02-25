using Microsoft.AspNetCore.Builder;
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
        private readonly IServiceProvider _services;

        public Metrics(ILogger<Metrics> logger, IServiceProvider services)
        {
            _services = services;
            _logger = logger;
        }

        public async Task DoWork()
        {
            using (var scope = _services.CreateScope())
            {
                var metricsService =
                   scope.ServiceProvider
                       .GetRequiredService<IScheduleService>();

                try
                {
                    var w = await metricsService.GetAllAsync();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            _logger.LogInformation("Timed Background Service is working.");

            //var schedules = await _scheduleService.GetAsync(new Guid("5475dd6a-ce84-4c4a-81bd-7fc27b0120ec"));
        }
    }
}
