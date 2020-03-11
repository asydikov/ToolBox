using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ToolBox.Services.DBWorker.Messages.Commands;
using static ToolBox.Common.Services.ServiceHost;

namespace ToolBox.Services.DBWorker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new RabbitmqHostBuilder(CreateHostBuilder(args).Build())
            .UserRabbitMq()
              .SubscribeToCommand<SqlStatementQuery>()
              .SubscribeToCommand<SqlStoredProcedureQuery>()
             .Build()
             .Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<Startup>()
                           .UseUrls("http://localhost:5040/");
                       });
    }
}
