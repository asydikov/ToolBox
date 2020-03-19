using RawRabbit.Configuration;

namespace ToolBox.Common.RabbitMq
{
    public class RabbitMqOptions : RawRabbitConfiguration
    {
        public string Namespace { get; set; }
    }
}