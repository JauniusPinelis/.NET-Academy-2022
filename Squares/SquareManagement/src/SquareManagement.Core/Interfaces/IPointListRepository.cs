using SquareManagement.Core.Model;

namespace SquareManagement.Core.Interfaces
{
    public interface IPointListRepository
    {
        Task<int> Insert(PointList pointList);
    }
}
