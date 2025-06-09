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

                config.CreateMap<User, UserDTO>();
                config.CreateMap<UserDTO, User>();

                config.CreateMap<Role, RoleDTO>();
                config.CreateMap<RoleDTO, Role>();

                config.CreateMap<CreateOrUpdateAddressDTO, AddressDTO>();
                config.CreateMap<CreateOrUpdateCinemaDTO, CinemaDTO>();
                config.CreateMap<CreateOrUpdateMovieDTO, MovieDTO>();
                config.CreateMap<CreateOrUpdateUserDTO, UserDTO>();
                config.CreateMap<CreateOrUpdateRoleDTO, RoleDTO>();
            })
            .CreateMapper();
        }
    }
}
