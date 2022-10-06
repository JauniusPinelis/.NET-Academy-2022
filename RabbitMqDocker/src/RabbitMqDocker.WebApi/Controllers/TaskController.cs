using Microsoft.AspNetCore.Mvc;
using RabbitMqDocker.Messaging;
using RabbitMqDocker.Messaging.Contracts;
using RabbitMqDocker.Repositories;

namespace RabbitMqDocker.WebApi.Controllers
{
    [ApiController]
    [Route("Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly TaskRepository _taskRepository;

        public TaskController(IMessagePublisher messagePublisher, TaskRepository taskRepository)
        {
            _messagePublisher = messagePublisher;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _taskRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask()
        {
            var task = new TaskCreated()
            {
                Id = 1
            };

            await _messagePublisher.Publish(task);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask()
        {
            var task = new TaskUpdated()
            {
                Id = 2
            };

            await _messagePublisher.Publish(task);

            return NoContent();
        }
    }
}
