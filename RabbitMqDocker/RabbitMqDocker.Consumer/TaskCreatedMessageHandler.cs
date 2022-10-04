using MassTransit;
using RabbitMqDocker.Messaging;
using RabbitMqDocker.Messaging.Contracts;

namespace RabbitMqDocker.Consumer
{
    public class TaskCreatedMessageHandler : Subscriber<TaskCreated>
    {
        public override Task Consume(ConsumeContext<TaskCreated> context)
        {
            var test = context.Message;
            return Task.CompletedTask;
        }
    }
}
