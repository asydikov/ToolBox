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
            //_logger.LogInformation("Timed Background Service is working.");

            using var scope = _services.CreateScope();

            var scheduleService = scope.ServiceProvider.GetRequiredService<IScheduleService>();
            var now = DateTime.Now;
            try
            {
                var schedules = await scheduleService.GetAllAsync(schedule =>
                                      now > schedule.LastInvokedDate.AddSeconds(schedule.Interval),
                                      includeAll: true);

                foreach (var schedule in schedules)
                {
                    await ScheduleExecute(schedule);
                    await ScheduleInvokeDateUpdate(scheduleService, schedule);
                }


            }
            catch (Exception ex)
            {
                _logger.LogError("Timed Background Service Error.");
            }

        }

        private async Task ScheduleInvokeDateUpdate(IScheduleService scheduleService, ScheduleModel model)
        {
            var tempModel = await scheduleService.GetAsync(model.Id);
            tempModel.LastInvokedDate = DateTime.Now;
            await scheduleService.UpdateAsync(tempModel);
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
                               server.UserId,
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
                               server.UserId,
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
