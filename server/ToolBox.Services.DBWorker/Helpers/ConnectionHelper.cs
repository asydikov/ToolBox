using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Services.DBWorker.Domain.Models;

namespace ToolBox.Services.DBWorker.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetConncetionString(ConnectionModel connectionModel) =>
                                                                                    $"Server={connectionModel.Host}, " +
                                                                                    $"{connectionModel.Port};" +
                                                                                    $" User Id={connectionModel.Login}; " +
                                                                                    $"Password={connectionModel.Password};" +
                                                                                    $" Database={connectionModel.DatabaseName}; " +
                                                                                    $"MultipleActiveResultSets=true";

        public static string GetConncetionStringWithTimeout(ConnectionModel connectionModel, int timeout = 2) =>
             $"{GetConncetionString(connectionModel)}; Connection Timeout={timeout}";

        public static string GetConncetionString(string host, int port, string login, string password, string databaseName) =>
              GetConncetionString(new ConnectionModel(host, port, login, password, databaseName));

        public static string GetConncetionStringWithTimeout(string host, int port, string login, string password, string databaseName, int timeout = 2) =>
           GetConncetionStringWithTimeout(new ConnectionModel(host, port, login, password, databaseName), timeout);
    }
}
