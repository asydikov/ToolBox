using RestEase;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;

namespace ToolBox.Services.SQLMonitor.RestEaseServices
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDbWorkerService
    {
        [AllowAnyStatusCode]
        [Post("api/dbWorker/server-connection-check")]
        Task<string> ServerConnectionCheck([Body] ConnectionModel connectionModel);
    }
}
