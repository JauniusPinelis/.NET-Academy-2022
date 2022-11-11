using AutoMapper;
using SquareManagement.Core.Model;
using SquareManagement.Services.Dtos;

namespace SquareManagement.Services.MappingProfiles
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<CreatePointList, PointList>();
        }
    }
}
