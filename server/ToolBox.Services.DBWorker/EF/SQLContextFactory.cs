using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolBox.Services.DBWorker.EF
{
    public class SQLContextFactory : ISQLContextFactory
    {
        public SQLDbContext GetSQLContext(SqlSettings settings)
        {
            string conntectionString = "Server=localhost, 1455; User Id=sa; Password=Pass_w0rd12; Database=master; MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<SQLDbContext>();
            optionsBuilder.UseSqlServer<SQLDbContext>(conntectionString);
            return new SQLDbContext(optionsBuilder.Options);
        }

    }
}
