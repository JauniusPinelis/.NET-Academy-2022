using FluentAssertions;
using NUnit.Framework;
using RabbitMqDocker.Repositories.Entities;
using System.Collections.Generic;
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
        public async Task Get_GetCall_ReturnsData()
        {
            _client = _factory.CreateClient();
            var result = await _client.GetAsync("/tasks");

            result.EnsureSuccessStatusCode();

            var tasks = await result.Content.ReadAsAsync<List<TaskEntity>>();

            tasks.Count.Should().Be(1);
        }

        //[Test]
        //public async Task Post_CreateTask_ReturnsCreatedId()
        //{
        //    _client = _factory.CreateClient();
        //    var result = await _client.PostAsync("/tasks", new { });

        //    result.EnsureSuccessStatusCode();

        //    var created = await result.Content.ReadAsAsync<List<TaskEntity>>();

        //    created.Count.Should().Be(1);
        //}
    }
}