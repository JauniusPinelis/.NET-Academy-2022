using Microsoft.AspNetCore.Mvc;
using RabbitMqDocker.Messaging;
using RabbitMqDocker.Messaging.Contracts;

namespace RabbitMqDocker.WebApi.Controllers
{
    [ApiController]
    [Route("Tasks")]
    public class TaskController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public TaskController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
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
