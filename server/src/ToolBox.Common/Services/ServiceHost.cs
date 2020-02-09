using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RawRabbit;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Common.RabbitMq;

namespace ToolBox.Common.Services
{
    /// The Service bus runs asynchronously
    public class ServiceHost : IServiceHost
    {
        private readonly IHost _webhost;
        public ServiceHost(IHost webhost)
        {
            _webhost = webhost;
        }
        public async Task Run() => await _webhost.RunAsync();

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class RabbitmqHostBuilder : BuilderBase
        {
            private readonly IHost _webHost;
            /// Responsible for sending and receiving messages
            private IBusClient _bus;

            public RabbitmqHostBuilder(IHost webHost)
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
            private readonly IHost _webHost;
            private IBusClient _bus;
            public BusBuilder(IHost webHost, IBusClient bus)
            {
                _webHost = webHost;
                _bus = bus;
            }

            ///https://stackoverflow.com/questions/55089755/cannot-resolve-scoped-service/55091641
            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHandler<TEvent>)_webHost.Services
                            .GetService(typeof(IEventHandler<TEvent>));
                _bus.WithEventHandlerAsync(handler);

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