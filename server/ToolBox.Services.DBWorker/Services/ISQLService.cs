using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBox.Services.DBWorker.Domain.Models;

namespace ToolBox.Services.DBWorker.Services
{
    public interface ISQLService
    {
        Task<List<Dictionary<string, string>>> SendSqlServerRequest(string conncectionString,
                                                                    string instruction,
                                                                    bool isProcedure = false,
                                                                    Dictionary<string, string> parameters = null);

        Task<bool> IsSqlConnected(ConnectionModel connectionModel);
    }
}