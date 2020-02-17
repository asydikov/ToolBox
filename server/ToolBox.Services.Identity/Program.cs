using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ToolBox.Services.Identity.Messages.Commands;
using static ToolBox.Common.Services.ServiceHost;

namespace ToolBox.Services.Identity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new RabbitmqHostBuilder(CreateHostBuilder(args).Build())
            .UserRabbitMq()
             .SubscribeToCommand<ChangePassword>()
             .Build()
             .Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<Startup>()
                           .UseUrls("http://localhost:5010/");
                       });
    }
}
