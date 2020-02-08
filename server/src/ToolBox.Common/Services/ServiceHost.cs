using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Common.RabbitMq;

namespace ToolBox.Common.Services
{
    /// The Service bus runs asynchronously
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webhost;
        public ServiceHost(IWebHost webhost)
        {
            _webhost = webhost;
        }
        public async Task Run() => await _webhost.RunAsync();
        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.WriteLine("Running rabbitmq server");
            Console.Title = typeof(TStartup).Namespace;
            var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(config)
            .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            /// Responsible for sending and receiving messages
            private IBusClient _bus;

            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UserRabbitMq()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));
                return new BusBuilder(_webHost, _bus);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

        public class BusBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;
            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                _webHost = webHost;
                _bus = bus;
            }

            ///https://stackoverflow.com/questions/55089755/cannot-resolve-scoped-service/55091641
            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var serviceScopeFactory = _webHost.Services.GetService<IServiceScopeFactory>();
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var handler = (IEventHandler<TEvent>)scope.ServiceProvider
                                .GetService(typeof(IEventHandler<TEvent>));
                    _bus.WithEventHandlerAsync(handler);
                }
                return this;
            }

            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)_webHost.Services
                            .GetService(typeof(ICommandHandler<TCommand>));
                _bus.WithCommandHandlerAsync(handler);
                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

    }
}