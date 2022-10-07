using BackkgroundTasksApi.Repositories;
using BackkgroundTasksApi.Settings;
using Microsoft.Extensions.Options;

namespace BackkgroundTasksApi.BackgroundServices
{
    public class TimedBackgroundHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedBackgroundHostedService> _logger;
        private Timer? _timer = null;

        private readonly BackgroundServiceSettings _settings;

        public IServiceProvider Services { get; }


        public TimedBackgroundHostedService(IServiceProvider services, ILogger<TimedBackgroundHostedService> logger,
            IOptions<BackgroundServiceSettings> options)
        {
            _logger = logger;
            Services = services;
            _settings = options.Value;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(_settings.RefreshRateInHours));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<TestRepository>();

                scopedProcessingService.CreateAsync().ConfigureAwait(true);
            }

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
