namespace BackkgroundTasksApi.Repositories
{
    public class TestRepository
    {
        private ILogger<TestRepository> _logger;

        public TestRepository(ILogger<TestRepository> logger)
        {
            _logger = logger;
        }

        public Task CreateAsync()
        {
            _logger.LogInformation("Created");

            return Task.CompletedTask;
        }
    }
}
