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
            var getAllQuery = "select * from public.shop_items";

            var entities = await _connection.QueryAsync<ShopItemEntity>(getAllQuery);

            return entities.ToList();
        }

        public async Task InsertAsync(ShopItemEntity shopItemEntity)
        {
            var insertQuery = "insert into public.shop_items (name, description) values (@name, @description)";

            await _connection.ExecuteAsync(insertQuery, new
            {
                shopItemEntity.Name,
                shopItemEntity.Description
            });
        }
    }
}
