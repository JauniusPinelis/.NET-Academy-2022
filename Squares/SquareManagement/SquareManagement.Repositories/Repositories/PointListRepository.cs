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

        public async Task<PointList> Get(int id)
        {
            string selectQuery = @"select * from public.pointlists where Id = @Id";

            return await _connection.QueryFirstAsync<PointList>(selectQuery, new
            {
                id
            });
        }

        public async Task<int> Create(PointList pointList)
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
            string removeQuery = @"remove from public.pointlists where Id = @Id";

            await _connection.ExecuteAsync(removeQuery, new
            {
                id
            });
        }
    }
}
