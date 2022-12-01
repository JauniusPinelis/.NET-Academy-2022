using AutoMapper;
using SquareManagement.Core.Model;
using SquareManagement.WebApi.Dtos.PointLists;

namespace SquareManagement.WebApi.MappingProfiles
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
