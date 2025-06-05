using Application.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _repository;
        private readonly IMapper _mapper;

        public CinemaService(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _repository = cinemaRepository;
            _mapper = mapper;
        }

        public IEnumerable<CinemaDTO> GetAll()
        {
            var cinemas = _repository.GetAll();

            return _mapper.Map<IEnumerable<CinemaDTO>>(cinemas);
        }

        public CinemaDTO GetById(int id)
        {
            var cinema = _repository.GetById(id);
            return _mapper.Map<CinemaDTO>(cinema);
        }

        public CinemaDTO Add(CreateOrUpdateCinemaDTO createCinemaDTO)
        {
            var cinemaDTO = _mapper.Map<CinemaDTO>(createCinemaDTO);

            var cinema = _mapper.Map<Cinema>(cinemaDTO);

            _repository.Add(cinema);

            return cinemaDTO;
        }

        public void Update(int id, CreateOrUpdateCinemaDTO updateCinemaDTO)
        {
            var cinemaDTO = GetById(id);

            cinemaDTO.Name = updateCinemaDTO.Name;
            cinemaDTO.Movies = updateCinemaDTO.Movies;
            cinemaDTO.Address = updateCinemaDTO.Address;

            var cinema = _mapper.Map<Cinema>(cinemaDTO);

            _repository.Update(cinema);
        }

        public void Delete(int id)
        {
            var cinema = _repository.GetById(id);

            _repository.Delete(cinema);
        }
    }
}
