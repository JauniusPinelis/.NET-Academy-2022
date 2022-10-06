using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace RabbitMqDocker.IntegrationTests
{
    public class TaskControllerTests
    {
        private CustomWebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Test]
        public async Task Test1()
        {
            _client = _factory.CreateClient();
            var result = await _client.GetAsync("/tasks");

            Assert.IsNotNull(result);
        }
    }
}