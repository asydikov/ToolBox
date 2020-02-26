using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToolBox.Services.SQLMonitor.EF;

//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2&tabs=visual-studio#timed-background-tasks
namespace ToolBox.Services.SQLMonitor.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMetrics _metrics;
        private Timer _timer;

        public TimedHostedService(IServiceProvider services, ILogger<Metrics> logger)
        {
            _logger = logger;
            _serviceProvider = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(2));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var metricsService =
                       scope.ServiceProvider
                           .GetRequiredService<IMetrics>();

                    metricsService.DoWork();
                }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
