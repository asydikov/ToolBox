using ToolBox.Services.SQLMonitor.EF;
using ToolBox.Services.SQLMonitor.Entities;

namespace ToolBox.Services.SQLMonitor.Repositories
{
    public class DatabaseRepository : RepositoryBase<Database>, IDatabaseRepository
    {
        public DatabaseRepository(SqlMonitorDbContext context) : base(context) { }
    }
}
