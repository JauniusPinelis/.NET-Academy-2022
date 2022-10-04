using MassTransit;

namespace RabbitMqDocker.Messaging
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessagePublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Publish<T>(T message)
        {
            await _publishEndpoint.Publish(message, CancellationToken.None);
        }
    }
}
