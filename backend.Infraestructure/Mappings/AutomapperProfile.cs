using AutoMapper;
using backend.Core.DTOs;
using backend.Core.Entities;
using backend.Infraestructure.Entities;
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

            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Club, ClubDto>().ReverseMap();

            CreateMap<Jugador, JugadorDto>().ReverseMap();
            CreateMap<Jugador, JugadorListDto>().ReverseMap();

        }
    }
}
