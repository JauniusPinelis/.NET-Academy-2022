using MassTransit;
using RabbitMqDocker.Messaging;
using RabbitMqDocker.Messaging.Contracts;

namespace RabbitMqDocker.Consumer
{
    public class TaskUpdatedMessageHandler : Subscriber<TaskUpdated>
    {
        public override Task Consume(ConsumeContext<TaskUpdated> context)
        {
            var test = context.Message;
            return Task.CompletedTask;
        }
    }
}
