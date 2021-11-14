using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Application.Dtos;
using WeatherApi.Entities;

namespace WeatherApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Weather, ReadWeatherDto>();
            CreateMap<CreateWeatherDto, Weather>();
            
        }
    }
}
