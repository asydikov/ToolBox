using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static ToolBox.Common.Services.ServiceHost;

namespace ToolBox.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new RabbitmqHostBuilder(CreateHostBuilder(args).Build())
           .UserRabbitMq()
           .Build()
           .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseUrls("http://api:5000/");
                });
    }
}
