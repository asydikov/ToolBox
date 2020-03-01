using RestEase;
using System.Threading.Tasks;
using ToolBox.Api.Domain.Models.SqlMonitor;

namespace ToolBox.Api.RestEaseServices
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ISqlMonitorService
    {
        [AllowAnyStatusCode]
        [Post("api/sqlmonitor/server-connection-check")]
        Task<bool> ServerConnectionCheck([Body] ConnectionModel connectionModel);
    }
}
