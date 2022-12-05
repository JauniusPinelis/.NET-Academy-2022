using Dapper;
using Npgsql;
using SquareManagement.Core.Interfaces;
using SquareManagement.Core.Model;

namespace SquareManagement.Repositories.Repositories
{
    public class PointListRepository : IPointListRepository
    {
        private readonly NpgsqlConnection _connection;

        public PointListRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<PointListModel> Get(int id)
        {
            string selectQuery = @"select * from public.point_lists where Id = @Id";

            return await _connection.QueryFirstAsync<PointListModel>(selectQuery, new
            {
                id
            });
        }

        public async Task<int> Create(PointListModel pointList)
        {
            string insertQuery = SqlConstants.InsertPointListCommand;

            var createdId = await _connection.ExecuteAsync(insertQuery, new
            {
                pointList.Name
            });

            return createdId;
        }

        public async Task Remove(int id)
        {
            string removeQuery = @"remove from public.point_lists where Id = @Id";

            await _connection.ExecuteAsync(removeQuery, new
            {
                id
            });
        }
    }
}
