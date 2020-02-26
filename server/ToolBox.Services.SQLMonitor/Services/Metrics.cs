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
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Commands;
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
                        await ScheduleExecute(schedule);
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }

        private async Task ScheduleExecute(ScheduleModel schedule)
        {
            foreach (var sqlScheduleQuery in schedule.ScheduleSqlQueries)
            {

                foreach (var scheduleServer in schedule.ScheduleServers)
                {

                    if (sqlScheduleQuery.SqlQuery.IsStoredProcedure)
                    {
                        await StoredProcedureInvoke(scheduleServer.Server, sqlScheduleQuery.SqlQuery);
                    }
                    else
                    {
                        await QueryInvoke(scheduleServer.Server, sqlScheduleQuery.SqlQuery);
                    }


                }
            }
        }

        private async Task QueryInvoke(ServerModel server, SqlQueryModel sqlQuery)
        {
            await _busClient.PublishAsync(new SqlStatementQuery(
                               Guid.NewGuid(),
                              sqlQuery.Query,
                              server.Host,
                              server.Port,
                              server.Login,
                              server.Password,
                              null,
                              server.Id,
                              Guid.Empty,
                              "sqlmonitor-service"
                               ));
        }

        private async Task StoredProcedureInvoke(ServerModel server, SqlQueryModel sqlQuery)
        {
            await _busClient.PublishAsync(new SqlStoredProcedureQuery(
                               Guid.NewGuid(),
                              sqlQuery.Query,
                              null,
                              server.Host,
                              server.Port,
                              server.Login,
                              server.Password,
                              null,
                              server.Id,
                              Guid.Empty,
                              "sqlmonitor-service"
                               ));
        }
    }
}
