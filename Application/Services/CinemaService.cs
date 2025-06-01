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

        public CinemaDTO Add(CinemaDTO cinemaDTO)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDTO);

            _repository.Add(cinema);

            return cinemaDTO;
        }

        public CinemaDTO Update(CinemaDTO cinemaDTO)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDTO);

            _repository.Update(cinema);

            return cinemaDTO;
        }

        public void Delete(int id)
        {
            var cinema = _repository.GetById(id);

            _repository.Delete(cinema);
        }
    }
}
