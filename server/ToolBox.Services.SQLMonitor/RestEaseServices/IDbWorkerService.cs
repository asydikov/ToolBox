using RestEase;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.Domain.Models;

namespace ToolBox.Services.SQLMonitor.RestEaseServices
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDbWorkerService
    {
        [AllowAnyStatusCode]
        [Get("api/dbWorker/server-connection-check")]
        Task<bool> ServerConnectionCheck([Body] ConnectionModel connectionModel);
    }
}
