using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToolBox.Services.DBWorker.Services
{
    public interface ISQLService
    {
        Task<List<Dictionary<string, string>>> SendSQLServerRequest(string conncectionString,
                                                             string instruction,
                                                             bool isProcedure = false,
                                                             Dictionary<string, string> parameters = null);
    }
}