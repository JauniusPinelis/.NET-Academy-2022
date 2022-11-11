using AutoMapper;
using SquareManagement.Core.Exceptions;
using SquareManagement.Core.Interfaces;
using SquareManagement.Core.Model;
using SquareManagement.Services.Dtos;

namespace SquareManagement.Services.Services
{
    public class PointListService
    {
        private readonly IPointListRepository _pointListRepository;
        private readonly IMapper _mapper;

        public PointListService(IPointListRepository pointListRepository, IMapper mapper)
        {
            _pointListRepository = pointListRepository;
            _mapper = mapper;
        }

        public async Task<PointListCreated> Create(CreatePointList createPointList)
        {
            var entity = _mapper.Map<PointList>(createPointList);

            var id = await _pointListRepository.Create(entity);

            return new PointListCreated
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
    }
}
