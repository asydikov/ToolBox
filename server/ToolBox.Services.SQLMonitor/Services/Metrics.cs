using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Messages.Commands.DbWorker;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class Metrics : IMetrics
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _services;
        private readonly IBusClient _busClient;

        public Metrics(IBusClient busClient, ILogger<Metrics> logger, IServiceProvider services)
        {
            _busClient = busClient;
            _services = services;
            _logger = logger;
        }

        public async Task DoWork()
        {
            _logger.LogInformation("Timed Background Service is working.");

            using (var scope = _services.CreateScope())
            {
                var scheduleService =
                   scope.ServiceProvider
                       .GetRequiredService<IScheduleService>();

                try
                {
                    var schedules = await scheduleService.GetAllAsync(predicate: null);
                    foreach (var schedule in schedules)
                    {
                        // _busClient.PublishAsync(new SqlStatementQuery());
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }
    }
}
