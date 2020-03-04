using RestEase;
using System;
using System.Collections.Generic;
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

        [AllowAnyStatusCode]
        [Get("api/dbWorker/time-consuming-queries")]
        Task<List<Dictionary<string, string>>> TimeConsumingQueries([Body]ConnectionModel model);
    }
}
