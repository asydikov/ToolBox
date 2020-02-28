using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Api.Domain.Models.SqlMonitor;

namespace ToolBox.Api.RestEaseServices
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ISqlMonitorService
    {
        [AllowAnyStatusCode]
        [Get("api/sqlmonitor/server-connection-check")]
        Task<object> ServerConnectionCheck([Body] ConnectionModel connectionModel);
    }
}
