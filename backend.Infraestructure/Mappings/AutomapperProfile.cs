using AutoMapper;
using backend.Core.DTOs;
using backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
          
        }
    }
}
