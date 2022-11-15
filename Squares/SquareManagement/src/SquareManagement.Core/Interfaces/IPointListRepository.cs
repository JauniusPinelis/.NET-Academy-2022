using SquareManagement.Core.Model;

namespace SquareManagement.Core.Interfaces
{
    public interface IPointListRepository
    {
        Task<int> Create(PointListModel pointList);
        Task Remove(int id);

        Task<PointListModel> Get(int id);
    }
}
