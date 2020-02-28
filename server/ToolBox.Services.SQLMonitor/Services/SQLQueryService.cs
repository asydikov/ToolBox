using AutoMapper;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Commands.DbWorker;
using ToolBox.Services.SQLMonitor.Repositories;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class SqlQueryService : ServiceBase<SqlQueryModel, SqlQuery>, ISqlQueryService
    {
        private readonly IBusClient _busClient;
        public SqlQueryService(IRepositoryBase<SqlQuery> repository, IMapper mapper, IBusClient busClient) : base(repository, mapper)
        {
            _busClient = busClient;
        }
    }
}
