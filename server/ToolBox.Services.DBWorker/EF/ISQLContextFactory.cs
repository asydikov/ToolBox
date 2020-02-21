using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.DBWorker.EF
{
    public interface ISQLContextFactory
    {
        SQLDbContext GetSQLContext(SqlSettings settings);
    }
}
