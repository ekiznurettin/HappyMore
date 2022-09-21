using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();  
            CreateMap<User, UserForLoginDto>().ReverseMap();  
        }
    }
}
