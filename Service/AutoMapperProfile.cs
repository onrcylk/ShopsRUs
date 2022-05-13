using AutoMapper;
using Common.Dto.User;
using Repository.Entities;
using System;

namespace Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
         
        }
    }
}
