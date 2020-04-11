using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ToolBox.Services.SQLMonitor.Messages.Commands;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using static ToolBox.Common.Services.ServiceHost;

namespace ToolBox.Services.SQLMonitor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new RabbitmqHostBuilder(CreateHostBuilder(args).Build())
            .UserRabbitMq()
             .SubscribeToEvent<DbWorkerOperationCompleted>()
             .SubscribeToEvent<DbWorkerOperationRejected>()
             .SubscribeToCommand<ServerCreation>()
             .Build()
             .Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<Startup>()
                           .UseUrls("http://sqlmonitor:5020/");
                       });
    }
}
