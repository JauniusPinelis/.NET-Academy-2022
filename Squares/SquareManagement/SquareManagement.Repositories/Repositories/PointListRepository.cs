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

        public async Task<int> Insert(PointList pointList)
        {
            string insertQuery = @"INSERT INTO [dbo].[point_lists]([Name]) VALUES (@Name)";

            var createdId = await _connection.ExecuteAsync(insertQuery, new
            {
                pointList.Name
            });

            return createdId;
        }
    }
}
