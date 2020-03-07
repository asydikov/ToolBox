using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ToolBox.Services.Notification.Messages.Events;
using static ToolBox.Common.Services.ServiceHost;

namespace ToolBox.Services.Notification
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new RabbitmqHostBuilder(CreateHostBuilder(args).Build())
           .UserRabbitMq()
           //.SubscribeToEvent<OperationPending>()
           .SubscribeToEvent<ServerMemoryUsageMetrics>()
           .SubscribeToEvent<UserSessionMetrics>()
           .SubscribeToEvent<OperationCompleted>()
           .SubscribeToEvent<OperationRejected>()
           .Build()
           .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                      .UseUrls("http://localhost:5050"); ;
                });
    }
}
