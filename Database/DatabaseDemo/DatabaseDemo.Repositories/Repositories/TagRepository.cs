using Dapper;
using DatabaseDemo.Repositories.Entities;
using Npgsql;

namespace DatabaseDemo.Repositories.Repositories
{
    public class TagRepository
    {
        private readonly NpgsqlConnection _connection;

        public TagRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Tag>> GetByShopId(int shopId)
        {
            var sqlBuilder = new SqlBuilder();

            var builderTemplate = sqlBuilder.AddTemplate("select t.* from shop_tag st /**innerjoin**/ /**where**/");
            sqlBuilder.InnerJoin("tag t on st.tag_id=t.id");
            sqlBuilder.Where("st.shop_id = @shopId", new
            {
                shopId
            });

            var entities = await _connection.QueryAsync<Tag>(builderTemplate.RawSql, builderTemplate.Parameters);
            return entities.ToList();
        }
    }
}
