using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.DBWorker.EF;

namespace ToolBox.Services.DBWorker.Services
{
    public class SQLServices
    {
        private readonly SQLDbContext _sqlDbContext;
        public SQLServices(ISQLContextFactory factory)
        {
            _sqlDbContext = factory.GetSQLContext(new SqlSettings());
        }
    }

}
