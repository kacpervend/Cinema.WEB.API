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
                config.CreateMap<AddressDTO, Address>();
                config.CreateMap<Cinema, CinemaDTO>();
                config.CreateMap<CinemaDTO, Cinema>();
                config.CreateMap<Movie, MovieDTO>();
                config.CreateMap<MovieDTO, Movie>();
            })
            .CreateMapper();
        }
    }
}
