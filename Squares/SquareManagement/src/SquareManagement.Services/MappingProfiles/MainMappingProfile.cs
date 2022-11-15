using AutoMapper;
using SquareManagement.Core.Model;
using SquareManagement.Services.Dtos.PointLists;

namespace SquareManagement.Services.MappingProfiles
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<CreatePointList, PointListModel>();
            CreateMap<PointListModel, PointList>();
        }
    }
}
