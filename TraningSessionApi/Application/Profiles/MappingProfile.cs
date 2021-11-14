using AutoMapper;
using TraningSessionApi.Application.Dtos;
using TraningSessionApi.Entities;

namespace TraningSessionApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap< Session, ReadSessionDto>();
            CreateMap<CreateSessionDto, Session>();
        }
    }
}
