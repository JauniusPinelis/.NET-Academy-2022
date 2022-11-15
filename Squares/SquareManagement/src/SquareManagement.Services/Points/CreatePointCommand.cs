using MediatR;
using SquareManagement.Services.Dtos.Points;
using SquareManagement.Services.Points.Dtos;

namespace SquareManagement.Services.Points
{
    public class CreatePointCommand : IRequest<PointCreated>
    {
        public int PointListId { get; set; }


        public CreatePoint CreatePoint { get; set; } = null!;
    }
}
