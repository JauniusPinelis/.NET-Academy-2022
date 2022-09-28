using Dapper;
using DatabaseDemo.Repositories.Entities;
using Npgsql;

namespace DatabaseDemo.Repositories.Repositories
{
    public class ShopRepository
    {
        private readonly NpgsqlConnection _connection;

        public ShopRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<ShopEntity> GetById(int id)
        {
            var sqlBuilder = new SqlBuilder();

            var builderTemplate = sqlBuilder.AddTemplate("select * from shop /**where**/");
            sqlBuilder.Where("id = @id", new
            {
                id
            });

            return await _connection.QueryFirstAsync<ShopEntity>(builderTemplate.RawSql, builderTemplate.Parameters);
        }
    }
}
