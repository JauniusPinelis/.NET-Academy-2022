using SquareManagement.Core.Exceptions;
using SquareManagement.Core.Interfaces;
using SquareManagement.Core.Model;

namespace SquareManagement.Services.Services
{
    public class PointListService
    {
        private readonly IPointListRepository _pointListRepository;

        public PointListService(IPointListRepository pointListRepository)
        {
            _pointListRepository = pointListRepository;
        }

        public async Task<PointListModel> Create(PointListModel createPointList)
        {
            var id = await _pointListRepository.Create(createPointList);

            return new PointListModel
            {
                Id = id,
            };
        }

        public async Task Remove(int id)
        {
            var pointList = await _pointListRepository.Get(id);

            if (pointList == null)
            {
                throw new PointListNotFoundException();
            }

            await _pointListRepository.Remove(id);
        }

        public async Task<PointListModel> Get(int id)
        {
            return await _pointListRepository.Get(id);
        }
    }
}
