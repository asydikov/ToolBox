using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Repositories;

namespace ToolBox.Services.SQLMonitor.Services
{
    public class DatabaseService : ServiceBase<DatabaseModel, Database>, IDatabaseService
    {

        public DatabaseService(IRepositoryBase<Database> repository,  IMapper mapper) : base(repository, mapper)
        {
           
        }

        public async Task AddDatabases(DbWorkerOperationCompleted command)
        {
            var databasesName = command.Result.SelectMany(x => x)
                .Where(x => x.Key == "databasE_NAME")
                .Select(x => new { DatabaseName = x.Value });

           var databases = databasesName.Select(x => 
            new Database { Name = x.DatabaseName, ServerId = command.SqlServerId }).ToList();

            await _repository.AddRangeAsync(databases);

           
        }
    }
}
