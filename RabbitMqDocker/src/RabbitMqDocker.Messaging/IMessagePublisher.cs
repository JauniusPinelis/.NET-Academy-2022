
namespace RabbitMqDocker.Messaging
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T message);
    }
}