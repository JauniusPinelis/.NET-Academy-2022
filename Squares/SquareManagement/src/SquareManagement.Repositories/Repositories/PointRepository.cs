using Dapper;
using Npgsql;
using SquareManagement.Core.Models;

namespace SquareManagement.Repositories.Repositories
{
    public class PointRepository
    {

        private readonly NpgsqlConnection _connection;

        public PointRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(PointModel pointModel)
        {
            string insertQuery = @$"Insert into dbo.points (x, y, pointlist_id) 
                                values ({pointModel.X}, {pointModel.Y},{pointModel.PointListId})";

            var createdId = await _connection.ExecuteAsync(insertQuery);

            return createdId;
        }
    }
}
