using AutoMapper;
using UserApi.Application.Dtos.User;
using UserApi.Application.Dtos.Weapon;
using UserApi.Entities;

namespace UserApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        //Source -> Target
        //User
        public MappingProfile()
        {
            //Source -> Target
            //User
            CreateMap<User, ReadUserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            //Weapon
            CreateMap<Weapon, ReadWeaponDto>();
            CreateMap<CreateWeaponDto, Weapon>();
            CreateMap<UpdateWeaponDto, Weapon>();
        }
    }
}
