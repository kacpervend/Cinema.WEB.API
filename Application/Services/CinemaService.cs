using Application.DTO;
using AutoMapper;
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
    }
}
