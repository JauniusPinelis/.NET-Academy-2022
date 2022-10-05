using Dapper;
using Npgsql;
using RabbitMqDocker.Repositories.Entities;

namespace RabbitMqDocker.Repositories
{
    public class TaskRepository
    {
        private readonly NpgsqlConnection _connection;

        public TaskRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<TaskEntity>> GetAllAsync()
        {
            var getAllQuery = "select * from public.tasks";

            var entities = await _connection.QueryAsync<TaskEntity>(getAllQuery);

            return entities.ToList();
        }

    }
}
