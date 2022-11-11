using SquareManagement.Core.Model;

namespace SquareManagement.Core.Interfaces
{
    public interface IPointListRepository
    {
        Task<int> Create(PointList pointList);
        Task Remove(int id);

        Task<PointList> Get(int id);
    }
}
