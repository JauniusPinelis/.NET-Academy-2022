using SquareManagement.Core.Models;

namespace SquareManagement.Repositories.Repositories
{
    public interface IPointRepository
    {
        Task<int> Create(PointModel pointModel);
    }
}