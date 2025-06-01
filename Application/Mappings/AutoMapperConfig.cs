using AutoMapper;
using Domain.Entities;
using Application.DTO;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Address, AddressDTO>();
                config.CreateMap<Cinema, CinemaDTO>();
                config.CreateMap<Movie, MovieDTO>();
            })
            .CreateMapper();
        }
    }
}
