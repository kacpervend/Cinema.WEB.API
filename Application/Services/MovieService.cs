using Application.DTO;
using AutoMapper;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _repository = movieRepository;
            _mapper = mapper;
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            var movies = _repository.GetAll();

            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public MovieDTO GetById(int id)
        {
            var movie = _repository.GetById(id);
            return _mapper.Map<MovieDTO>(movie);
        }
    }
}
