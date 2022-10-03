using AutoMapper;
using FirstWebApi.Dtos;
using FirstWebApi.Entities;

namespace FirstWebApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePerson, PersonEntity>();
            CreateMap<UpdatePerson, PersonEntity>();
            CreateMap<PersonEntity, Person>();
        }
    }
}
