using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Common.Services;
using static ToolBox.Common.Services.ServiceHost;

namespace ToolBox.Services.Identity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new RabbitmqHostBuilder(CreateHostBuilder(args))
            .UserRabbitMq()
             .SubscribeToCommand<CreateUser>()
             .Build()
             .Run();
        }
        public static IHost CreateHostBuilder(string[] args) =>
                   Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<Startup>();
                       }).Build();
    }
}
