using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.DBWorker.Domain.Models;

namespace ToolBox.Services.DBWorker.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetConncetionString(ConnectionModel connectionModel)
        {
            return $"Server={connectionModel.Host}, {connectionModel.Port}; User Id={connectionModel.Login}; Password={connectionModel.Password}; Database={connectionModel.DatabaseName}; MultipleActiveResultSets=true";

        }

        public static string GetConncetionStringWithTimeout(ConnectionModel connectionModel, int timeout = 2)
        {
            return $"{GetConncetionString(connectionModel)}; Connection Timeout={timeout}";
        }
    }
}
