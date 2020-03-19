using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using System.Reflection;
using RawRabbit.Common;
using System;
using System.Net;
using Toolbox.Common.Messages;
using Toolbox.Common;

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

    class CustomNamingConventions : NamingConventions
    {
        public CustomNamingConventions(string defaultNamespace)
        {
            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            ExchangeNamingConvention = type => GetNamespace(type, defaultNamespace).ToLowerInvariant();
            RoutingKeyConvention = type => $"{GetRoutingKeyNamespace(type, defaultNamespace)}{type.Name.Underscore()}".ToLowerInvariant();
            QueueNamingConvention = type => GetQueueName(assemblyName, type, defaultNamespace);
            ErrorExchangeNamingConvention = () => $"{defaultNamespace}.error";
            RetryLaterExchangeConvention = span => $"{defaultNamespace}.retry";
            RetryLaterQueueNameConvetion = (exchange, span) =>
                $"{defaultNamespace}.retry_for_{exchange.Replace(".", "_")}_in_{span.TotalMilliseconds}_ms".ToLowerInvariant();
        }

        private static string GetRoutingKeyNamespace(Type type, string defaultNamespace)
        {
            var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;

            return string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";
        }

        private static string GetNamespace(Type type, string defaultNamespace)
        {
            var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;

            return string.IsNullOrWhiteSpace(@namespace) ? type.Name.Underscore() : $"{@namespace}";
        }

        private static string GetQueueName(string assemblyName, Type type, string defaultNamespace)
        {
            var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;
            var separatedNamespace = string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";

            return $"{assemblyName}/{separatedNamespace}{type.Name.Underscore()}".ToLowerInvariant();
        }
    }
}