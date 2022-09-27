using Dapper;
using DatabaseDemo.Repositories.Entities;
using Npgsql;

namespace DatabaseDemo.Repositories.Repositories
{
    public class ShopItemRepository
    {
        private readonly NpgsqlConnection _connection;

        public ShopItemRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<ShopItemEntity>> GetAllAsync()
        {
            var getAllQuery = "select * from public.actor";

            var entities = await _connection.QueryAsync<ShopItemEntity>(getAllQuery);

            return entities.ToList();
        }
    }
}
