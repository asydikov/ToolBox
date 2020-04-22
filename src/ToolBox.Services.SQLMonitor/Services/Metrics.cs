using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using ToolBox.Services.SQLMonitor.Domain.Enums;
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
        private readonly IDataProtector _protector;

        public Metrics(IBusClient busClient, ILogger<Metrics> logger, IServiceProvider services, IDataProtectionProvider dataProtector)
        {
            _busClient = busClient;
            _services = services;
            _logger = logger;
            _protector = dataProtector.CreateProtector("sql-server-pass-protector");
        }

        public async Task DoWork()
        {
            using var scope = _services.CreateScope();
          
            try
            {
                var scheduleService = scope.ServiceProvider.GetRequiredService<IScheduleService>();
                var now = DateTime.Now;

                var schedules = await scheduleService.GetAllAsync(schedule =>
                                      now > schedule.LastInvokedDate.AddSeconds(schedule.Interval),
                                      includeAll: true);
                if (schedules.Any(x => x.ScheduleServers.Any()) == false)
                {
                    return;
                }
                foreach (var schedule in schedules)
                {
                    await ScheduleExecute(schedule);
                    await ScheduleInvokeDateUpdate(scheduleService, schedule);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Establishing connection...");
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
                        if (sqlScheduleQuery.SqlQuery.Name == SqlQueryNames.DatabaseSpaceStatus)
                        {
                            // Execute query on each databases
                            await DbStoredProcedureInvoke(scheduleServer.Server, sqlScheduleQuery.SqlQuery);
                        }
                        else
                        {
                            await StoredProcedureInvoke(scheduleServer.Server, sqlScheduleQuery.SqlQuery);
                        }
                    }
                    else
                    {
                        await QueryInvoke(scheduleServer.Server, sqlScheduleQuery.SqlQuery);
                    }

                }
            }
        }

        private async Task DbStoredProcedureInvoke(ServerModel server, SqlQueryModel sqlQuery)
        {
            foreach (var database in server.Databases)
            {
                await _busClient.PublishAsync(new SqlStoredProcedureQuery(Guid.NewGuid(),
                                                                     server.UserId,
                                                                     sqlQuery.Query,
                                                                     new Dictionary<string, string> { { "@oneresultset", "1" } },
                                                                     server.Host,
                                                                     server.Port,
                                                                     server.Login,
                                                                     _protector.Unprotect(server.Password),
                                                                     database.Name,
                                                                     (int)sqlQuery.Name,
                                                                     server.Id,
                                                                     database.Id,
                                                                     "sqlmonitor-service"
                                                                      ));
            }
        }

        private async Task QueryInvoke(ServerModel server, SqlQueryModel sqlQuery)
        {

            await _busClient.PublishAsync(new SqlStatementQuery(Guid.NewGuid(),
                                                                server.UserId,
                                                                sqlQuery.Query,
                                                                server.Host,
                                                                server.Port,
                                                                server.Login,
                                                                _protector.Unprotect(server.Password),
                                                                null,
                                                                (int)sqlQuery.Name,
                                                                server.Id,
                                                                Guid.Empty,
                                                                "sqlmonitor-service"
                                                                 ));
        }

        private async Task StoredProcedureInvoke(ServerModel server, SqlQueryModel sqlQuery)
        {
            await _busClient.PublishAsync(new SqlStoredProcedureQuery(Guid.NewGuid(),
                                                                      server.UserId,
                                                                      sqlQuery.Query,
                                                                      null,
                                                                      server.Host,
                                                                      server.Port,
                                                                      server.Login,
                                                                      _protector.Unprotect(server.Password),
                                                                      null,
                                                                      (int)sqlQuery.Name,
                                                                      server.Id,
                                                                      Guid.Empty,
                                                                      "sqlmonitor-service"
                                                                       ));
        }
    }
}
