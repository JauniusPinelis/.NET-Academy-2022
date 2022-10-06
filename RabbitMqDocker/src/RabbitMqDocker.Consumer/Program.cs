// See https://aka.ms/new-console-template for more information
using MassTransit;
using RabbitMqDocker.Consumer;

Console.WriteLine("Hello, World!");

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("rabbitmq", "/", h =>
    {
        h.Username("guest");
        h.Password("guest");
    });

    cfg.ReceiveEndpoint("task-created-queue", e =>
    {
        e.Consumer<TaskCreatedMessageHandler>();
    });

    cfg.ReceiveEndpoint("task-updated-queue", e =>
    {
        e.Consumer<TaskUpdatedMessageHandler>();
    });
});

await busControl.StartAsync(new CancellationToken());
try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}
