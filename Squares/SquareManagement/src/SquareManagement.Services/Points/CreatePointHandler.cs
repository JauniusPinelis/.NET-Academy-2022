using MediatR;
using SquareManagement.Services.Points.Dtos;
using SquareManagement.Services.Services;

namespace SquareManagement.Services.Points
{
    public class CreatePointHandler : IRequestHandler<CreatePointCommand, PointCreated>
    {
        private PointService _pointService;
        private PointListService _pointListService;

        public CreatePointHandler(PointService pointService, PointListService pointListService)
        {
            _pointService = pointService;
            _pointListService = pointListService;
        }

        public async Task<PointCreated> Handle(CreatePointCommand request, CancellationToken cancellationToken)
        {
            var pointList = await _pointListService.Get(request.PointListId);

            if (pointList == null)
            {
                throw new ArgumentException();
            }

            // this is where flow going to be
            // and this will employ and use individual services.
            _pointService.Create(request.PointListId, request.CreatePoint);

            return new PointCreated
            {

            };

        }
    }
}
