using MassTransit;

namespace RabbitMqDocker.Messaging
{
    public abstract class Subscriber<T> : IConsumer<T> where T : class
    {
        public abstract Task Consume(ConsumeContext<T> context);
    }
}
