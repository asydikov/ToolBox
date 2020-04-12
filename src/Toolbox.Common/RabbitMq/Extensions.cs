using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using RawRabbit.Common;
using System.Net;

namespace ToolBox.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg));

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            var namingConventions = new CustomNamingConventions(options.Namespace);
            section.Bind(options);
            var rawRabbitOptions = new RawRabbitOptions
            {
                ClientConfiguration = options,
                DependencyInjection = ioc =>
                {
                    ioc.AddSingleton<INamingConventions>(namingConventions);
                }
            };
            var client = RawRabbitFactory.CreateSingleton(rawRabbitOptions);
            services.AddSingleton<IBusClient>(_ => client);
        }
    }
}